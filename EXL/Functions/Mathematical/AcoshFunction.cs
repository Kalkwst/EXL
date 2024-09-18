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

            Checks.CanConvertToDouble(args[0], "ACOSH function requires a numeric value.", out double number);

            if (number < 1)
            {
                throw new InvalidOperationException("The input for ACOSH must be greater than or equal to 1.");
            }

            return Math.Acosh(number);  // Return the inverse hyperbolic cosine of the number
        }
    }

}
