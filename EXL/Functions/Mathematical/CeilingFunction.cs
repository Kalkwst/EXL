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

            Checks.CanConvertToDouble(args[0], "CEILING function requires a number argument.", out double number);
            Checks.CanConvertToDouble(args[1], "CEILING function requires a significance argument.", out double significance);

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
