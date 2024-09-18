using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXL.Functions.Mathematical
{
    public class AcoshFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("ACOSH function requires exactly one argument: number.");
            }

            double number = Convert.ToDouble(args[0]);

            if (number < 1)
            {
                throw new InvalidOperationException("The input for ACOSH must be greater than or equal to 1.");
            }

            return Math.Acosh(number);  // Return the inverse hyperbolic cosine of the number
        }
    }

}
