using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class AtanFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length == 1)
            {
                if (!Checks.TryConvertToDouble(args[0], out var number))
                {
                    throw new InvalidOperationException("ACOS function requires a numeric value.");
                }

                return Math.Atan(number);  // Return the arctangent in radians
            }
            else if (args.Length == 2)
            {
                // Two arguments: Compute the arctangent based on (x, y) coordinates
                if (!Checks.TryConvertToDouble(args[0], out var x))
                {
                    throw new InvalidOperationException("ACOS function requires a numeric value.");
                }

                if (!Checks.TryConvertToDouble(args[1], out var y))
                {
                    throw new InvalidOperationException("ACOS function requires a numeric value.");
                }

                return Math.Atan2(x, y);  // Return the angle in radians
            }
            else
            {
                throw new InvalidOperationException("ATAN function requires one or two arguments.");
            }
        }
    }

}

