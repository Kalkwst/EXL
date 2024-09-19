namespace EXL.Functions.Mathematical
{
    /// <summary>
    /// Provides the implementation of the ABS function which returns the absolute value of a number or each element in an array of numbers.
    /// </summary>
    public class AbsFunction : IFunction
    {
        /// <summary>
        /// Executes the ABS function on the provided arguments.
        /// </summary>
        /// <param name="args">A single numeric value or an array of numeric values.</param>
        /// <returns>The absolute value of the provided numeric value or an array of absolute values if an array was provided.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the number of arguments is not one or the argument is not a numeric value or array of numbers.</exception>
        public object Execute(params object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("ABS function accepts a single value or an array");
            }

            var arg = args[0];

            return arg switch
            {
                double[] array => array.Select(Math.Abs).ToArray(), // Apply ABS to each element in the array
                double d => Math.Abs(d), // Apply ABS to the single double value
                int i => Math.Abs(i), // Apply ABS to the single int value
                _ => throw new InvalidOperationException("ABS function requires a numeric value or array of numbers"),
            };
        }
    }

}
