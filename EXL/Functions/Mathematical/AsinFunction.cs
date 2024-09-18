using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class AsinFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("ASIN function requires exactly one argument: number.");
            }

            Checks.CanConvertToDouble(args[0], "ASIN function requires a number argument", out double number);

            if (number < -1 || number > 1)
            {
                throw new InvalidOperationException("The number argument for ASIN must be between -1 and 1.");
            }

            return Math.Asin(number);  // Return the arcsine of the number
        }
    }

}
