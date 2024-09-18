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

            double number = Convert.ToDouble(args[0]);

            if (number < -1 || number > 1)
            {
                throw new InvalidOperationException("The number argument for ASIN must be between -1 and 1.");
            }

            return Math.Asin(number);  // Return the arcsine of the number
        }
    }

}
