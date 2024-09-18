using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class CosFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("COS function requires exactly one argument: number.");
            }

            Checks.CanConvertToDouble(args[0], "COS function requires a number argument", out double number);

            return Math.Cos(number);  // Return the cosine of the angle (in radians)
        }
    }
}
