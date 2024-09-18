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

            Checks.CanConvertToDouble(args[0], "COMBINATION function requires a number argument for n.", out double x);
            Checks.CanConvertToDouble(args[1], "COMBINATION function requires a number argument for k.", out double y);

            int n = (int)Math.Floor(x);  // Truncate to integer
            int k = (int)Math.Floor(y);  // Truncate to integer

            if (n < 0 || k < 0 || n < k)
            {
                throw new InvalidOperationException("COMBINATION function requires number >= 0, number_chosen >= 0, and number >= number_chosen.");
            }

            return Factorial(n) / (Factorial(k) * Factorial(n - k));
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
