using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXL.Functions.Mathematical
{
    public class QuotientFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 2)
            {
                throw new InvalidOperationException("QUOTIENT function requires exactly two arguments: numerator and denominator.");
            }

            double numerator = Convert.ToDouble(args[0]);
            double denominator = Convert.ToDouble(args[1]);

            if (denominator == 0)
            {
                throw new InvalidOperationException("Division by zero in QUOTIENT function.");
            }

            // Return the integer portion of the division
            return (int)(numerator / denominator);
        }
    }
}
