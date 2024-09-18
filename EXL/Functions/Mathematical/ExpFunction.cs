namespace EXL.Functions.Mathematical
{
    public class ExpFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("EXP function requires exactly one argument: number.");
            }

            double number = Convert.ToDouble(args[0]);

            return Math.Exp(number);  // Return e raised to the power of number
        }
    }

}
