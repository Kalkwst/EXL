using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class ModFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 2)
            {
                throw new InvalidOperationException("MOD function requires exactly two arguments: number and divisor.");
            }

            if (!Checks.TryConvertToDouble(args[0], out var number))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            if (!Checks.TryConvertToDouble(args[0], out var divisor))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            if (divisor == 0)
            {
                throw new InvalidOperationException("Division by zero in MOD function.");
            }

            return number - divisor * Math.Floor(number / divisor);  // MOD formula
        }
    }
}
