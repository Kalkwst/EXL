using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXL.Functions.Mathematical
{
    public class CosFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("COS function requires exactly one argument: number.");
            }

            double number = Convert.ToDouble(args[0]);

            return Math.Cos(number);  // Return the cosine of the angle (in radians)
        }
    }
}
