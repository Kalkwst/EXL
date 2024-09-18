using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            int n = (int)Math.Floor(Convert.ToDouble(args[0]));  // Truncate to integer
            int k = (int)Math.Floor(Convert.ToDouble(args[1]));  // Truncate to integer

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
