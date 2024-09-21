using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class CombinationFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 2)
            {
                throw new InvalidOperationException("COMBINATION function requires exactly two arguments: number and number_chosen.");
            }

            if (!Checks.TryConvertToDouble(args[0], out var x))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            if (!Checks.TryConvertToDouble(args[1], out var y))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            int n = (int)Math.Floor(x);  // Truncate to integer
            int k = (int)Math.Floor(y);  // Truncate to integer

            if (n < 0 || k < 0 || n < k)
            {
                throw new InvalidOperationException("COMBINATION function requires number >= 0, number_chosen >= 0, and number >= number_chosen.");
            }

            return this.Factorial(n) / (this.Factorial(k) * this.Factorial(n - k));
        }

        private double Factorial(int number)
        {
            if (number == 0 || number == 1)
            {
                return 1;
            }

            double result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
    }

}
