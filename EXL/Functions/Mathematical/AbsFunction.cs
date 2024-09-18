using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXL.Functions.Mathematical
{
    public class AbsFunction : IFunction
    {
        public object Execute(params object[] args)
        {
            if (args.Length == 1)
            {
                var arg = args[0];

                if (arg is double[])
                {
                    var array = (double[])arg;
                    return array.Select(Math.Abs).ToArray();  // Apply ABS to each element in the array
                }
                else if (arg is double || arg is int)
                {
                    return Math.Abs(Convert.ToDouble(arg));  // Apply ABS to the single value
                }
                else
                {
                    throw new InvalidOperationException("ABS function requires a numeric value or array of numbers");
                }
            }
            else
            {
                throw new InvalidOperationException("ABS function accepts a single value or an array");
            }
        }
    }

}
