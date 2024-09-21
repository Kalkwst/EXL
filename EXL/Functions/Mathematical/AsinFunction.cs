using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    /// <summary>
    /// Provides the implementation of the ASIN function which returns the arcsine of a number.
    /// </summary>
    public class AsinFunction : IFunction
    {
        /// <summary>
        /// Executes the ASIN function on the provided argument.
        /// </summary>
        /// <param name="args">An array containing a single numeric value.</param>
        /// <returns>The arcsine of the provided numeric value.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the number of arguments is not one, the argument is not a numeric value, 
        /// or the numeric value is not between -1 and 1.
        /// </exception>
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("ASIN function requires exactly one argument: number.");
            }

            if (!Checks.TryConvertToDouble(args[0], out double number))
            {
                throw new InvalidOperationException("ASIN function requires a number argument.");
            }

            if (number < -1 || number > 1)
            {
                throw new InvalidOperationException("The number argument for ASIN must be between -1 and 1.");
            }

            return Math.Asin(number);  // Return the arcsine of the number
        }
    }

}
