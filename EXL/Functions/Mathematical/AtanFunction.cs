using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class AtanFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length == 1)
            {
                Checks.CanConvertToDouble(args[0], "ATAN function requires a numeric value.", out double number);
                return Math.Atan(number);  // Return the arctangent in radians
            }
            else if (args.Length == 2)
            {
                // Two arguments: Compute the arctangent based on (x, y) coordinates
                Checks.CanConvertToDouble(args[0], "ATAN function requires a numeric value for the x-coordinate.", out double x);
                Checks.CanConvertToDouble(args[1], "ATAN function requires a numeric value for the y-coordinate.", out double y);
                
                return Math.Atan2(x, y);  // Return the angle in radians
            }
            else
            {
                throw new InvalidOperationException("ATAN function requires one or two arguments.");
            }
        }
    }

}

