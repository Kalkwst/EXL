using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXL.Functions.Mathematical
{
    public class LogFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length < 1 || args.Length > 2)
            {
                throw new InvalidOperationException("LOG function requires one or two arguments: number and an optional base.");
            }

            double number = Convert.ToDouble(args[0]);

            if (number <= 0)
            {
                throw new InvalidOperationException("The number argument for LOG must be a positive real number.");
            }

            if (args.Length == 2)
            {
                double logBase = Convert.ToDouble(args[1]);
                return Math.Log(number, logBase);  // Return the logarithm of the number with the specified base
            }
            else
            {
                return Math.Log10(number);  // Default to base 10 if no base is provided
            }
        }
    }

}
