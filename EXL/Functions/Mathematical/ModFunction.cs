using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class ModFunction : IFunction
    {
        public object Execute(object[] args)
        {
            if (args.Length != 2)
            {
                throw new InvalidOperationException("MOD function requires exactly two arguments: number and divisor.");
            }

            Checks.CanConvertToDouble(args[0], "MOD function requires a number argument", out double number);
            Checks.CanConvertToDouble(args[1], "MOD function requires a divisor argument", out double divisor);

            if (divisor == 0)
            {
                throw new InvalidOperationException("Division by zero in MOD function.");
            }

            return number - divisor * Math.Floor(number / divisor);  // MOD formula
        }
    }
}
