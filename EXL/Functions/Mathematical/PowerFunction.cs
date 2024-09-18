namespace EXL.Functions.Mathematical
{
    public class PowerFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 2)
            {
                throw new InvalidOperationException("POWER function requires exactly two arguments: number and power.");
            }

            double number = Convert.ToDouble(args[0]);
            double power = Convert.ToDouble(args[1]);

            return Math.Pow(number, power);  // Return number raised to the power
        }
    }

}
