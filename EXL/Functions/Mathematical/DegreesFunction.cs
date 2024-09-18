using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class DegreesFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("DEGREES function requires exactly one argument: angle in radians.");
            }

            Checks.CanConvertToDouble(args[0], "DEGREES function requires a numeric value.", out double radians);

            return radians * (180.0 / Math.PI);  // Convert radians to degrees
        }
    }

}
