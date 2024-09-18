using EXL;

// Define a context with variable values
var context = new Dictionary<string, object>
{
    { "A", 10 },
       { "B", 20 },
            { "C", 30 },
            { "D", 5 },
            { "E", 15 },

            { "X", new double[] { 1, 2, 3 } },
            { "Y", new double[] { 4, 5, 6 } },
            {"KITSOS", "GEIA SOU KOSTI"},
        };

// Example complex expression
string expression = "MAX({X})";
var tokenizer = new Tokenizer(expression);
var parser = new Parser(tokenizer, context);
var result1234 = parser.ParseExpression();
Console.WriteLine($"Result: {result1234}");  // Outpu
