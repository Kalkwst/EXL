using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXL.Functions.Mathematical
{
    public class CeilingFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 2)
            {
                throw new InvalidOperationException("CEILING function requires exactly two arguments: number and significance.");
            }

            double number = Convert.ToDouble(args[0]);
            double significance = Convert.ToDouble(args[1]);

            if (significance == 0)
            {
                throw new InvalidOperationException("Significance cannot be zero in CEILING function.");
            }

            if (number > 0 && significance > 0)
            {
                return Math.Ceiling(number / significance) * significance;
            }
            else if (number < 0 && significance < 0)
            {
                return Math.Floor(number / significance) * significance;
            }
            else if (number < 0 && significance > 0)
            {
                return Math.Ceiling(number / significance) * significance;
            }
            else
            {
                throw new InvalidOperationException("CEILING function requires both arguments to be non-zero and valid numbers.");
            }
        }
    }

}
