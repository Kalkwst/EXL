using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXL.Functions.Array
{
    public class CountFunction : IFunction
    {
        public object Execute(object[] args)
        {
            // Ensure there's exactly one argument and it is an array
            if (args.Length != 1 || args[0] is not double[])
            {
                throw new InvalidOperationException("The COUNT function requires a single array as input.");
            }

            // Convert the input to an array
            var array = (double[])args[0];

            // Return the length of the array
            return array.Length;
        }
    }

}
