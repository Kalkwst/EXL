using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class AsinhFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("ASINH function requires exactly one argument: number.");
            }

            Checks.CanConvertToDouble(args[0], "ASINH function requires a number argument", out double number);

            return Math.Asinh(number);  // Return the inverse hyperbolic sine of the number
        }
    }

}
