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
            _input = input;
            _position = 0;
        }

        private char CurrentChar => _position < _input.Length ? _input[_position] : '\0';

        public Token GetNextToken()
        {
            while (CurrentChar != '\0')
            {
                if (char.IsWhiteSpace(CurrentChar))
                {
                    _position++;
                    continue;
                }

                // Handle strings enclosed in quotes
                if (CurrentChar == '"' || CurrentChar == '\'')
                {
                    return GetString();
                }

                // Handle numbers
                if (char.IsDigit(CurrentChar) || CurrentChar == '.')
                {
                    return GetNumber();
                }

                // Handle operators
                if (CurrentChar == '+')
                {
                    _position++;
                    return new Token(TokenType.ADDITION, "+");
                }

                if (CurrentChar == '-')
                {
                    _position++;
                    return new Token(TokenType.SUBTRACTION, "-");
                }

                if (CurrentChar == '*')
                {
                    _position++;
                    return new Token(TokenType.MULTIPLICATION, "*");
                }

                if (CurrentChar == '/')
                {
                    _position++;
                    return new Token(TokenType.DIVISION, "/");
                }

                // Handle variables enclosed in curly braces
                if (CurrentChar == '{')
                {
                    return GetVariable();
                }

                // Handle number arrays starting with [
                if (CurrentChar == '[')
                {
                    return GetArray();
                }

                if (CurrentChar == '(')
                {
                    _position++;
                    return new Token(TokenType.LEFT_PAREN, "(");
                }

                if (CurrentChar == ')')
                {
                    _position++;
                    return new Token(TokenType.RIGHT_PAREN, ")");
                }

                if (CurrentChar == ',')
                {
                    _position++;
                    return new Token(TokenType.COMMA, ",");
                }


                if (char.IsLetter(CurrentChar))
                {
                    return GetFunctionOrVariable();  // Handle functions or variables
                }

                throw new InvalidOperationException($"Unexpected character: {CurrentChar}");
            }

            return new Token(TokenType.EOF, null);
        }

        private Token GetString()
        {
            var stringDelimiter = CurrentChar;
            _position++; // Skip the starting quote

            var sb = new StringBuilder();
            while (CurrentChar != '\0' && CurrentChar != stringDelimiter)
            {
                sb.Append(CurrentChar);
                _position++;
            }

            if (CurrentChar == stringDelimiter)
            {
                _position++; // Skip the ending quote
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

            while (char.IsDigit(CurrentChar) || (!haveDecimalPoint && CurrentChar == '.'))
            {
                sb.Append(CurrentChar);
                haveDecimalPoint = CurrentChar == '.';
                _position++;
            }

            return new Token(TokenType.NUMBER, sb.ToString());
        }

        private Token GetFunctionOrVariable()
        {
            var sb = new StringBuilder();
            while (char.IsLetter(CurrentChar))
            {
                sb.Append(CurrentChar);
                _position++;
            }

            // If followed by '(', it's a function
            if (CurrentChar == '(')
            {
                return new Token(TokenType.FUNCTION, sb.ToString().ToUpperInvariant());  // Return function name as uppercase
            }

            // Otherwise, it's a variable
            return new Token(TokenType.VARIABLE, sb.ToString());
        }

        private Token GetVariable()
        {
            _position++; // Skip the opening brace '{'

            var sb = new StringBuilder();
            while (CurrentChar != '\0' && CurrentChar != '}')
            {
                sb.Append(CurrentChar);
                _position++;
            }

            if (CurrentChar == '}')
            {
                _position++; // Skip the closing brace '}'
            }
            else
            {
                throw new InvalidOperationException("Unterminated variable reference");
            }

            return new Token(TokenType.VARIABLE, sb.ToString());
        }

        private bool IsStartOfBoolean()
        {
            var remainingInput = _input.Substring(_position).ToLower();
            return remainingInput.StartsWith("true") || remainingInput.StartsWith("false");
        }

        private Token GetBoolean()
        {
            var remainingInput = _input.Substring(_position).ToLower();
            if (remainingInput.StartsWith("true"))
            {
                _position += 4; // Move past "true"
                return new Token(TokenType.BOOL, "TRUE");
            }
            else if (remainingInput.StartsWith("false"))
            {
                _position += 5; // Move past "false"
                return new Token(TokenType.BOOL, "FALSE");
            }

            throw new InvalidOperationException("Invalid boolean value");
        }

        private Token GetBooleanOrVariable()
        {
            var sb = new StringBuilder();
            while (char.IsLetter(CurrentChar))
            {
                sb.Append(CurrentChar);
                _position++;
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
            _position++; // Skip the opening bracket '['

            var elements = new List<string>();
            var elementType = TokenType.NUMBER; // Default to number array initially

            while (CurrentChar != '\0' && CurrentChar != ']')
            {
                // Skip commas and spaces
                if (CurrentChar == ',' || char.IsWhiteSpace(CurrentChar))
                {
                    _position++;
                    continue;
                }

                // Check the type of the next element
                if (char.IsDigit(CurrentChar) || CurrentChar == '.')
                {
                    elements.Add(GetNumber().Value);
                    elementType = TokenType.NUMBER_ARRAY;
                }
                else if (CurrentChar == '"' || CurrentChar == '\'')
                {
                    elements.Add(GetString().Value);
                    elementType = TokenType.STRING_ARRAY;
                }
                else if (char.IsLetter(CurrentChar))
                {
                    var boolToken = GetBooleanOrVariable();
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

            if (CurrentChar == ']')
            {
                _position++; // Skip the closing bracket ']'
            }
            else
            {
                throw new InvalidOperationException("Unterminated array");
            }

            return new Token(elementType, string.Join(",", elements)); // Join the elements into a string for simplicity
        }
    }

}
