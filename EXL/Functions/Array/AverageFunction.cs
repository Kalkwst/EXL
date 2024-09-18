using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXL.Functions.Array
{
    public class AverageFunction : IFunction
    {
        public object Execute(object[] args)
        {
            // Ensure there's exactly one argument and it is an array
            if (args.Length != 1 || args[0] is not double[])
            {
                throw new InvalidOperationException("The AVERAGE function requires a single array as input.");
            }

            // Convert the input to a double array
            var array = ((double[])args[0]).OfType<double>().ToArray();

            if (array.Length == 0)
            {
                throw new InvalidOperationException("Cannot calculate the average of an empty array.");
            }

            // Calculate the sum of the array
            double sum = array.Sum();

            // Return the average
            return sum / array.Length;
        }
    }

}
