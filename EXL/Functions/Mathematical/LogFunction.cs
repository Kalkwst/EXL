using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class LogFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length < 1 || args.Length > 2)
            {
                throw new InvalidOperationException("LOG function requires one or two arguments: number and an optional base.");
            }

            if (!Checks.TryConvertToDouble(args[0], out var number))
            {
                throw new InvalidOperationException("ACOS function requires a numeric value.");
            }

            if (number <= 0)
            {
                throw new InvalidOperationException("The number argument for LOG must be a positive real number.");
            }

            if (args.Length == 2)
            {
                if (!Checks.TryConvertToDouble(args[1], out var logBase))
                {
                    throw new InvalidOperationException("ACOS function requires a numeric value.");
                }
                return Math.Log(number, logBase);  // Return the logarithm of the number with the specified base
            }
            else
            {
                return Math.Log10(number);  // Default to base 10 if no base is provided
            }
        }
    }

}
