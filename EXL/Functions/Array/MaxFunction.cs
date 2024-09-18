using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXL.Functions.Array
{
    public class MaxFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1 || !(args[0] is double[]))
            {
                throw new InvalidOperationException("The MAX function requires a single array as input.");
            }

            var array = ((double[])args[0]).OfType<double>().ToArray();
            if (array.Length == 0) throw new InvalidOperationException("double[] cannot be empty.");

            return array.Max();
        }
    }

}
