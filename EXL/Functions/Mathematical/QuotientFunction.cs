using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class QuotientFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 2)
            {
                throw new InvalidOperationException("QUOTIENT function requires exactly two arguments: numerator and denominator.");
            }

            Checks.CanConvertToDouble(args[0], "QUOTIENT function requires a numerator argument", out double numerator);
            Checks.CanConvertToDouble(args[1], "QUOTIENT function requires a denominator argument", out double denominator);

            if (denominator == 0)
            {
                throw new InvalidOperationException("Division by zero in QUOTIENT function.");
            }

            // Return the integer portion of the division
            return (int)(numerator / denominator);
        }
    }
}
