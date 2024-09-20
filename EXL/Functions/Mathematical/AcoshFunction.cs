using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    /// <summary>
    /// Provides the implementation of the ACOSH function which returns the inverse hyperbolic cosine of a number.
    /// </summary>
    public class AcoshFunction : IFunction
    {
        /// <summary>
        /// Executes the ACOSH function on the provided argument.
        /// </summary>
        /// <param name="args">An array containing a single numeric value.</param>
        /// <returns>The inverse hyperbolic cosine of the provided numeric value.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the number of arguments is not one, the argument is not a numeric value, 
        /// or the numeric value is less than 1.
        /// </exception>
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("ACOSH function requires exactly one argument: number.");
            }

            if (!Checks.TryConvertToDouble(args[0], out double number))
            {
                throw new InvalidOperationException("ACOSH function requires a numeric value.");
            }

            if (number < 1)
            {
                throw new InvalidOperationException("The input for ACOSH must be greater than or equal to 1.");
            }

            return Math.Acosh(number);  // Return the inverse hyperbolic cosine of the number
        }
    }
}
