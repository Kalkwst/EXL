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

            if (!Checks.TryConvertToDouble(args[0], out var number))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            return Math.Exp(number);  // Return e raised to the power of number
        }
    }

}
