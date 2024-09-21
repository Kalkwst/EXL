using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class CosFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("COS function requires exactly one argument: number.");
            }

            if (!Checks.TryConvertToDouble(args[0], out var number))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            return Math.Cos(number);  // Return the cosine of the angle (in radians)
        }
    }
}
