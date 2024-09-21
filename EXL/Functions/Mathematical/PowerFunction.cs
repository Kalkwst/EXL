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

            if (!Checks.TryConvertToDouble(args[0], out var number))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            if (!Checks.TryConvertToDouble(args[0], out var power))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            return Math.Pow(number, power);  // Return number raised to the power
        }
    }

}
