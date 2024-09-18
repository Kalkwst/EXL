using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXL.Functions.Mathematical
{
    public class OddFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("ODD function requires exactly one argument: number.");
            }

            double number = Convert.ToDouble(args[0]);

            // Check if the input is nonnumeric
            if (double.IsNaN(number))
            {
                throw new InvalidOperationException("The input for ODD must be a numeric value.");
            }

            // Round up to the nearest odd integer, adjusting away from zero
            if (number > 0)
            {
                // If the number is already odd, return it
                if (Math.Floor(number) % 2 != 0)
                {
                    return Math.Floor(number);
                }
                return Math.Ceiling((number + 1) / 2) * 2 - 1;
            }
            else
            {
                if (Math.Floor(number) % 2 != 0)
                {
                    return Math.Floor(number);
                }
                return Math.Floor((number - 1) / 2) * 2 + 1;
            }
        }
    }

}
