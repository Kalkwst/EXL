using EXL.Utils;

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

            Checks.CanConvertToDouble(args[0], "POWER function requires a number argument", out double number);
            Checks.CanConvertToDouble(args[1], "POWER function requires a power argument", out double power);

            return Math.Pow(number, power);  // Return number raised to the power
        }
    }

}
