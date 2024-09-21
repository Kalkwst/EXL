using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    /// <summary>
    /// Represents a function that calculates the arccosine of a number.
    /// </summary>
    public class AcosFunction : IFunction
    {
        /// <summary>
        /// Executes the ACOS function with the specified arguments.
        /// </summary>
        /// <param name="args">An array containing a single numeric argument.</param>
        /// <returns>The arccosine of the specified number.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the number of arguments is not exactly one,
        /// or when the argument is not a numeric value,
        /// or when the numeric value is not between -1 and 1.
        /// </exception>
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("ACOS function requires exactly one argument: number.");
            }

            if (args[0] is not double number && !Checks.TryConvertToDouble(args[0], out number))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            if (number is < -1.0 or > 1.0)
            {
                throw new InvalidOperationException("The number argument for ACOS must be between -1 and 1.");
            }

            return Math.Acos(number);
        }
    }
}
