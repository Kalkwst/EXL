using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class SinFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("SIN function requires exactly one argument: number.");
            }

            if (!Checks.TryConvertToDouble(args[0], out var number))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            return Math.Sin(number);  // Return the sine of the angle (in radians)
        }
    }

}
