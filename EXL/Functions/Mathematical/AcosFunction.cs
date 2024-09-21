using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class AcosFunction : IFunction
    {

        public object Execute(object[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("ACOS function requires exactly one argument: number.");
            }

            if (!Checks.TryConvertToDouble(args[0], out var number))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            if (number < -1.0 || number > 1.0)
            {
                throw new InvalidOperationException("The number argument for ACOS must be between -1 and 1.");
            }

            return Math.Acos(number);
        }
    }
}
