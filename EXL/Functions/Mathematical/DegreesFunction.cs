using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class DegreesFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("DEGREES function requires exactly one argument: angle in radians.");
            }

            if (!Checks.TryConvertToDouble(args[0], out var radians))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            return radians * (180.0 / Math.PI);  // Convert radians to degrees
        }
    }

}
