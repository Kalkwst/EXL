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

            if (!Checks.TryConvertToDouble(args[0], out var numerator))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            if (!Checks.TryConvertToDouble(args[0], out var denominator))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            if (denominator == 0)
            {
                throw new InvalidOperationException("Division by zero in QUOTIENT function.");
            }

            // Return the integer portion of the division
            return (int)(numerator / denominator);
        }
    }
}
