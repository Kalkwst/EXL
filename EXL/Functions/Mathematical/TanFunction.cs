using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class TanFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("TAN function requires exactly one argument: number.");
            }

            Checks.CanConvertToDouble(args[0], "TAN function requires a number argument", out double number);

            return Math.Tan(number);  // Return the tangent of the angle (in radians)
        }
    }

}
