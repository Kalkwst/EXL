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

            if (args[0] is not double number && !Checks.TryConvertToDouble(args[0], out number))
            {
                throw new InvalidOperationException("ASIN function requires a number argument.");
            }

            if (number is < -1.0 or > 1.0)
            {
                throw new InvalidOperationException("The number argument for ASIN must be between -1 and 1.");
            }

            return Math.Asin(number);  // Return the arcsine of the number
        }
    }
}
