using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXL.Functions.Mathematical
{
    public class ModFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 2)
            {
                throw new InvalidOperationException("MOD function requires exactly two arguments: number and divisor.");
            }

            double number = Convert.ToDouble(args[0]);
            double divisor = Convert.ToDouble(args[1]);

            if (divisor == 0)
            {
                throw new InvalidOperationException("Division by zero in MOD function.");
            }

            return number - divisor * Math.Floor(number / divisor);  // MOD formula
        }
    }
}
