using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXL.Functions.Mathematical
{
    public class AsinhFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("ASINH function requires exactly one argument: number.");
            }

            double number = Convert.ToDouble(args[0]);

            return Math.Asinh(number);  // Return the inverse hyperbolic sine of the number
        }
    }

}
