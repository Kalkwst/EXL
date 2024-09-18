using EXL.Utils;

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

            Checks.CanConvertToDouble(args[0], "EXP function requires a number argument", out double number);

            return Math.Exp(number);  // Return e raised to the power of number
        }
    }

}
