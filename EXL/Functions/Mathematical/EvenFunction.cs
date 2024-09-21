using EXL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXL.Functions.Mathematical
{
    public class EvenFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("EVEN function requires exactly one argument: number.");
            }

            if (!Checks.TryConvertToDouble(args[0], out var number))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            // Check if the input is nonnumeric
            if (double.IsNaN(number))
            {
                throw new InvalidOperationException("The input for EVEN must be a numeric value.");
            }

            // Round up to the nearest even integer, adjusting away from zero
            if (number > 0)
            {
                return Math.Ceiling(number / 2) * 2;
            }
            else
            {
                return Math.Floor(number / 2) * 2;
            }
        }
    }

}
