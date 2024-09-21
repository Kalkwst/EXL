using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXL
{
    public class Tokenizer
    {
        private readonly string _input;
        private int _position;

        public Tokenizer(string input)
        {
            this._input = input;
            this._position = 0;
        }

        private char CurrentChar => this._position < this._input.Length ? this._input[this._position] : '\0';

        public Token GetNextToken()
        {
            while (this.CurrentChar != '\0')
            {
                if (char.IsWhiteSpace(this.CurrentChar))
                {
                    this._position++;
                    continue;
                }

                // Handle strings enclosed in quotes
                if (this.CurrentChar == '"' || this.CurrentChar == '\'')
                {
                    return this.GetString();
                }

                // Handle numbers
                if (char.IsDigit(this.CurrentChar) || this.CurrentChar == '.')
                {
                    return this.GetNumber();
                }

                // Handle operators
                if (this.CurrentChar == '+')
                {
                    this._position++;
                    return new Token(TokenType.ADDITION, "+");
                }

                if (this.CurrentChar == '-')
                {
                    this._position++;
                    return new Token(TokenType.SUBTRACTION, "-");
                }

                if (this.CurrentChar == '*')
                {
                    this._position++;
                    return new Token(TokenType.MULTIPLICATION, "*");
                }

                if (this.CurrentChar == '/')
                {
                    this._position++;
                    return new Token(TokenType.DIVISION, "/");
                }

                // Handle variables enclosed in curly braces
                if (this.CurrentChar == '{')
                {
                    return this.GetVariable();
                }

                // Handle number arrays starting with [
                if (this.CurrentChar == '[')
                {
                    return this.GetArray();
                }

                if (this.CurrentChar == '(')
                {
                    this._position++;
                    return new Token(TokenType.LEFT_PAREN, "(");
                }

                if (this.CurrentChar == ')')
                {
                    this._position++;
                    return new Token(TokenType.RIGHT_PAREN, ")");
                }

                if (this.CurrentChar == ',')
                {
                    this._position++;
                    return new Token(TokenType.COMMA, ",");
                }


                if (char.IsLetter(this.CurrentChar))
                {
                    return this.GetFunctionOrVariable();  // Handle functions or variables
                }

                throw new InvalidOperationException($"Unexpected character: {this.CurrentChar}");
            }

            return new Token(TokenType.EOF, null);
        }

        private Token GetString()
        {
            var stringDelimiter = this.CurrentChar;
            this._position++; // Skip the starting quote

            var sb = new StringBuilder();
            while (this.CurrentChar != '\0' && this.CurrentChar != stringDelimiter)
            {
                sb.Append(this.CurrentChar);
                this._position++;
            }

            if (this.CurrentChar == stringDelimiter)
            {
                this._position++; // Skip the ending quote
            }
            else
            {
                throw new InvalidOperationException("Unterminated string literal");
            }

            return new Token(TokenType.STRING, sb.ToString());
        }

        private Token GetNumber()
        {
            var sb = new StringBuilder();
            bool haveDecimalPoint = false;

            while (char.IsDigit(this.CurrentChar) || (!haveDecimalPoint && this.CurrentChar == '.'))
            {
                sb.Append(this.CurrentChar);
                haveDecimalPoint = this.CurrentChar == '.';
                this._position++;
            }

            return new Token(TokenType.NUMBER, sb.ToString());
        }

        private Token GetFunctionOrVariable()
        {
            var sb = new StringBuilder();
            while (char.IsLetter(this.CurrentChar))
            {
                sb.Append(this.CurrentChar);
                this._position++;
            }

            // If followed by '(', it's a function
            if (this.CurrentChar == '(')
            {
                return new Token(TokenType.FUNCTION, sb.ToString().ToUpperInvariant());  // Return function name as uppercase
            }

            // Otherwise, it's a variable
            return new Token(TokenType.VARIABLE, sb.ToString());
        }

        private Token GetVariable()
        {
            this._position++; // Skip the opening brace '{'

            var sb = new StringBuilder();
            while (this.CurrentChar != '\0' && this.CurrentChar != '}')
            {
                sb.Append(this.CurrentChar);
                this._position++;
            }

            if (this.CurrentChar == '}')
            {
                this._position++; // Skip the closing brace '}'
            }
            else
            {
                throw new InvalidOperationException("Unterminated variable reference");
            }

            return new Token(TokenType.VARIABLE, sb.ToString());
        }

        private bool IsStartOfBoolean()
        {
            var remainingInput = this._input.Substring(this._position).ToLower();
            return remainingInput.StartsWith("true") || remainingInput.StartsWith("false");
        }

        private Token GetBoolean()
        {
            var remainingInput = this._input.Substring(this._position).ToLower();
            if (remainingInput.StartsWith("true"))
            {
                this._position += 4; // Move past "true"
                return new Token(TokenType.BOOL, "TRUE");
            }
            else if (remainingInput.StartsWith("false"))
            {
                this._position += 5; // Move past "false"
                return new Token(TokenType.BOOL, "FALSE");
            }

            throw new InvalidOperationException("Invalid boolean value");
        }

        private Token GetBooleanOrVariable()
        {
            var sb = new StringBuilder();
            while (char.IsLetter(this.CurrentChar))
            {
                sb.Append(this.CurrentChar);
                this._position++;
            }

            var word = sb.ToString().ToUpperInvariant();  // Convert to uppercase for case-insensitivity

            if (word == "TRUE" || word == "FALSE")
            {
                return new Token(TokenType.BOOL, word);
            }

            // If not a boolean, assume it's a variable (for now)
            return new Token(TokenType.VARIABLE, word);
        }

        private Token GetArray()
        {
            this._position++; // Skip the opening bracket '['

            var elements = new List<string>();
            var elementType = TokenType.NUMBER; // Default to number array initially

            while (this.CurrentChar != '\0' && this.CurrentChar != ']')
            {
                // Skip commas and spaces
                if (this.CurrentChar == ',' || char.IsWhiteSpace(this.CurrentChar))
                {
                    this._position++;
                    continue;
                }

                // Check the type of the next element
                if (char.IsDigit(this.CurrentChar) || this.CurrentChar == '.')
                {
                    elements.Add(this.GetNumber().Value);
                    elementType = TokenType.NUMBER_ARRAY;
                }
                else if (this.CurrentChar == '"' || this.CurrentChar == '\'')
                {
                    elements.Add(this.GetString().Value);
                    elementType = TokenType.STRING_ARRAY;
                }
                else if (char.IsLetter(this.CurrentChar))
                {
                    var boolToken = this.GetBooleanOrVariable();
                    if (boolToken.Type == TokenType.BOOL)
                    {
                        elements.Add(boolToken.Value);
                        elementType = TokenType.BOOL_ARRAY;
                    }
                    else
                    {
                        throw new InvalidOperationException("Only boolean values are allowed in boolean arrays");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Invalid element in array");
                }
            }

            if (this.CurrentChar == ']')
            {
                this._position++; // Skip the closing bracket ']'
            }
            else
            {
                throw new InvalidOperationException("Unterminated array");
            }

            return new Token(elementType, string.Join(",", elements)); // Join the elements into a string for simplicity
        }
    }

}
