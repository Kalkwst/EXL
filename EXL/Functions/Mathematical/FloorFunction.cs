namespace EXL.Functions.Mathematical
{
    public class FloorFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 2)
            {
                throw new InvalidOperationException("FLOOR function requires exactly two arguments: number and significance.");
            }

            if (args[0] is not double number || args[1] is not double significance)
            {
                throw new InvalidOperationException("FLOOR function requires numeric values.");
            }

            if (significance == 0)
            {
                throw new InvalidOperationException("Significance cannot be zero.");
            }

            if (number > 0 && significance < 0)
            {
                throw new InvalidOperationException("If number is positive, significance cannot be negative.");
            }

            double result = number >= 0
                ? Math.Floor(number / significance) * significance
                : Math.Ceiling(number / significance) * significance;  // For negative numbers, round down away from zero

            return result;
        }
    }

}
