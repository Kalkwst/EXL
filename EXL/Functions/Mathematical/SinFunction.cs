using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class SinFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("SIN function requires exactly one argument: number.");
            }

            Checks.CanConvertToDouble(args[0], "SIN function requires a number argument", out double number);

            return Math.Sin(number);  // Return the sine of the angle (in radians)
        }
    }

}
