namespace EXL.Functions.Mathematical
{
    public class AtanFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length == 1)
            {
                // Single argument: Compute the arctangent of the number
                double number = Convert.ToDouble(args[0]);
                return Math.Atan(number);  // Return the arctangent in radians
            }
            else if (args.Length == 2)
            {
                // Two arguments: Compute the arctangent based on (y, x) coordinates
                double y = Convert.ToDouble(args[0]);
                double x = Convert.ToDouble(args[1]);
                return Math.Atan2(y, x);  // Return the angle in radians
            }
            else
            {
                throw new InvalidOperationException("ATAN function requires one or two arguments.");
            }
        }
    }

}

