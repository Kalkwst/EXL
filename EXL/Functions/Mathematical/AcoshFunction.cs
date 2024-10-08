using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class AcoshFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("ACOSH function requires exactly one argument: number.");
            }

            if (!Checks.TryConvertToDouble(args[0], out var number))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            if (number < 1)
            {
                throw new InvalidOperationException("The input for ACOSH must be greater than or equal to 1.");
            }

            return Math.Acosh(number);  // Return the inverse hyperbolic cosine of the number
        }
    }

}
