using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXL.Functions.Mathematical
{
    public class SinFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("SIN function requires exactly one argument: number.");
            }

            double number = Convert.ToDouble(args[0]);

            return Math.Sin(number);  // Return the sine of the angle (in radians)
        }
    }

}
