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

            double radians = Convert.ToDouble(args[0]);

            return radians * (180.0 / Math.PI);  // Convert radians to degrees
        }
    }

}
