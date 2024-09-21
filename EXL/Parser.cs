using EXL.Functions;
using System.Globalization;

namespace EXL
{
    public class Parser
    {
        private readonly Tokenizer _tokenizer;
        private readonly Dictionary<string, object> _context;
        private readonly FunctionFactory _functionFactory;
        private Token _currentToken;

        public Parser(Tokenizer tokenizer, Dictionary<string, object> context)
        {
            this._tokenizer = tokenizer;
            this._context = context;
            this._currentToken = this._tokenizer.GetNextToken();
            this._functionFactory = new FunctionFactory();
        }

        private void Eat(TokenType tokenType)
        {
            if (this._currentToken.Type == tokenType)
            {
                this._currentToken = this._tokenizer.GetNextToken();
            }
            else
            {
                throw new InvalidOperationException($"Unexpected token: {this._currentToken.Type}");
            }
        }

        // Parse expressions involving addition and subtraction (lower precedence)
        public object ParseExpression()
        {
            var result = this.ParseTerm();

            while (this._currentToken.Type == TokenType.ADDITION || this._currentToken.Type == TokenType.SUBTRACTION)
            {
                if (this._currentToken.Type == TokenType.ADDITION)
                {
                    this.Eat(TokenType.ADDITION);
                    var right = this.ParseTerm();

                    // Handle array concatenation only for the '+' operator
                    if (result is double[] && right is double[])
                    {
                        result = this.CombineArrays((double[])result, (double[])right);
                    }
                    else if (result is string[] && right is string[])
                    {
                        result = this.CombineArrays((string[])result, (string[])right);
                    }
                    else if (result is string || right is string)
                    {
                        result = result.ToString() + right.ToString();  // Concatenate strings
                    }
                    else
                    {
                        result = Convert.ToDouble(result) + Convert.ToDouble(right);  // Perform addition
                    }
                }
                else if (this._currentToken.Type == TokenType.SUBTRACTION)
                {
                    this.Eat(TokenType.SUBTRACTION);
                    var right = this.ParseTerm();

                    // Disallow subtraction for arrays, but allow for numbers and strings
                    if (result is double[] || right is double[])
                    {
                        throw new InvalidOperationException("Subtraction is not allowed for arrays.");
                    }
                    else if (result is string || right is string)
                    {
                        throw new InvalidOperationException("Subtraction is not allowed for strings.");
                    }
                    else
                    {
                        result = Convert.ToDouble(result) - Convert.ToDouble(right);  // Perform subtraction for numbers
                    }
                }
            }

            return result;
        }


        // Parse terms involving multiplication and division (higher precedence)
        private object ParseTerm()
        {
            var result = this.ParseFactor();

            while (this._currentToken.Type == TokenType.MULTIPLICATION || this._currentToken.Type == TokenType.DIVISION)
            {
                if (this._currentToken.Type == TokenType.MULTIPLICATION)
                {
                    this.Eat(TokenType.MULTIPLICATION);
                    var right = this.ParseFactor();
                    result = Convert.ToDouble(result) * Convert.ToDouble(right);  // Perform multiplication
                }
                else if (this._currentToken.Type == TokenType.DIVISION)
                {
                    this.Eat(TokenType.DIVISION);
                    var right = this.ParseFactor();

                    if (Convert.ToDouble(right) == 0)
                    {
                        throw new InvalidOperationException("Division by zero is not allowed");
                    }

                    result = Convert.ToDouble(result) / Convert.ToDouble(right);  // Perform division
                }
            }

            return result;
        }

        // Parse factors: numbers, variables, and expressions inside parentheses
        private object ParseFactor()
        {
            if (this._currentToken.Type == TokenType.LEFT_PAREN)
            {
                // Handle parentheses
                this.Eat(TokenType.LEFT_PAREN);
                var result = this.ParseExpression();  // Parse the expression inside the parentheses
                this.Eat(TokenType.RIGHT_PAREN);  // Match the closing parenthesis
                return result;
            }

            if (this._currentToken.Type == TokenType.LEFT_BRACKET)
            {
                // Handle arrays
                return this.ParseArray();
            }

            var token = this._currentToken;

            if (token.Type == TokenType.NUMBER)
            {
                this.Eat(TokenType.NUMBER);
                return token.Value.Contains(".") ? double.Parse(token.Value) : int.Parse(token.Value);
            }

            if (token.Type == TokenType.STRING)
            {
                this.Eat(TokenType.STRING);
                return token.Value;  // Return string as-is
            }

            if (token.Type == TokenType.BOOL)
            {
                this.Eat(TokenType.BOOL);
                return token.Value == "TRUE";  // Return true or false
            }

            if (token.Type == TokenType.VARIABLE)
            {
                var variableName = token.Value;
                this.Eat(TokenType.VARIABLE);

                if (this._context.ContainsKey(variableName))
                {
                    return this._context[variableName];
                }
                else
                {
                    throw new InvalidOperationException($"Undefined variable: {variableName}");
                }
            }

            if (this._currentToken.Type == TokenType.FUNCTION)
            {
                return this.ParseFunction();
            }

            throw new InvalidOperationException($"Unexpected token: {token.Type}");
        }

        private object ParseArray()
        {
            this.Eat(TokenType.LEFT_BRACKET);  // Consume the opening bracket '['

            var elements = new List<object>();
            var arrayType = TokenType.NUMBER_ARRAY;  // Default to number array

            while (this._currentToken.Type != TokenType.RIGHT_BRACKET)
            {
                if (this._currentToken.Type == TokenType.COMMA)
                {
                    this.Eat(TokenType.COMMA);  // Consume commas between array elements
                }
                else
                {
                    var element = this.ParseFactor();  // Parse each element inside the array
                    elements.Add(element);

                    // Determine the array type dynamically
                    if (element is string)
                    {
                        arrayType = TokenType.STRING_ARRAY;
                    }
                    else if (element is bool)
                    {
                        arrayType = TokenType.BOOL_ARRAY;
                    }
                }
            }

            this.Eat(TokenType.RIGHT_BRACKET);  // Consume the closing bracket ']'

            // Convert the elements to an appropriate array based on type
            return arrayType switch
            {
                TokenType.NUMBER_ARRAY => elements.Cast<double>().ToArray(),
                TokenType.STRING_ARRAY => elements.Cast<string>().ToArray(),
                TokenType.BOOL_ARRAY => elements.Cast<bool>().ToArray(),
                _ => throw new InvalidOperationException("Unknown array type")
            };
        }

        private object ParseFunction()
        {
            var functionName = this._currentToken.Value;
            this.Eat(TokenType.FUNCTION);

            this.Eat(TokenType.LEFT_PAREN);  // Expect '('

            // Parse arguments inside the function call
            var args = new List<object>();
            while (this._currentToken.Type != TokenType.RIGHT_PAREN)
            {
                args.Add(this.ParseExpression());

                if (this._currentToken.Type == TokenType.COMMA)
                {
                    this.Eat(TokenType.COMMA);  // Consume comma between arguments
                }
            }

            this.Eat(TokenType.RIGHT_PAREN);  // Expect ')'

            // Retrieve and execute the function using the factory
            var function = this._functionFactory.GetFunction(functionName);
            return function.Execute(args.ToArray());
        }


        private double[] CombineArrays(double[] array1, double[] array2)
        {
            return array1.Concat(array2).ToArray();  // Concatenate the arrays
        }

        private string[] CombineArrays(string[] array1, string[] array2)
        {
            return array1.Concat(array2).ToArray();  // Concatenate string arrays
        }

    }

}
