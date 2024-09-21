using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class AsinhFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("ASINH function requires exactly one argument: number.");
            }

            if (!Checks.TryConvertToDouble(args[0], out var number))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            return Math.Asinh(number);  // Return the inverse hyperbolic sine of the number
        }
    }

}
