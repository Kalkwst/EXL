namespace EXL
{
    public enum TokenType
    {
        NUMBER,
        STRING,
        BOOL,
        NUMBER_ARRAY,
        STRING_ARRAY,
        BOOL_ARRAY,
        ADDITION,
        SUBTRACTION,
        MULTIPLICATION,
        DIVISION,
        VARIABLE,
        LEFT_PAREN,
        RIGHT_PAREN,
        LEFT_BRACKET,
        RIGHT_BRACKET,
        COMMA,
        FUNCTION,
        EOF
    }

    public class Token
    {
        public TokenType Type { get; private set; }
        public string Value { get; private set; }

        public Token(TokenType type, string value)
        {
            this.Type = type;
            this.Value = value;
        }
    }

}
