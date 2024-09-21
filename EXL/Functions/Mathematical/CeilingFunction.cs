using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class CeilingFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 2)
            {
                throw new InvalidOperationException("CEILING function requires exactly two arguments: number and significance.");
            }

            if (!Checks.TryConvertToDouble(args[0], out var number))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            if (!Checks.TryConvertToDouble(args[1], out var significance))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            if (significance == 0)
            {
                throw new InvalidOperationException("Significance cannot be zero in CEILING function.");
            }

            if (number > 0 && significance > 0)
            {
                return Math.Ceiling(number / significance) * significance;
            }
            else if (number < 0 && significance < 0)
            {
                return Math.Floor(number / significance) * significance;
            }
            else if (number < 0 && significance > 0)
            {
                return Math.Ceiling(number / significance) * significance;
            }
            else
            {
                throw new InvalidOperationException("CEILING function requires both arguments to be non-zero and valid numbers.");
            }
        }
    }

}
