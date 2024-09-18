using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXL.Functions.Mathematical
{
    public class AcosFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("ACOS function requires exactly one argument: number.");
            }

            double number;
            try
            {
                number = Convert.ToDouble(args[0]);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The argument for ACOS must be a numeric value.", ex);
            }

            if (number < -1 || number > 1)
            {
                throw new InvalidOperationException("The number argument for ACOS must be between -1 and 1.");
            }

            return Math.Acos(number);  // Return the arccosine of the number
        }
    }
}
