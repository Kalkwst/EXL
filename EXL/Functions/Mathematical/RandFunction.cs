using EXL.Utils;

namespace EXL.Functions.Mathematical
{
    public class RandFunction : IFunction
    {
        private static readonly Random random = new Random();  // Create a static Random instance

        public object Execute(object[] args)
        {
            if (args.Length == 0)
            {
                // No arguments: Return a random number between 0 and 1
                return random.NextDouble();
            }
            else if (args.Length == 1)
            {
                // One argument: Return a random number between 1 and the argument
                Checks.CanConvertToDouble(args[0], "RAND function requires a number argument", out double max);

                if (max <= 1)
                {
                    throw new InvalidOperationException("For one argument, the value must be greater than 1.");
                }

                return 1 + (random.NextDouble() * (max - 1));
            }
            else if (args.Length == 2)
            {
                // Two arguments: Return a random number between min and max
                Checks.CanConvertToDouble(args[0], "RAND function requires a number argument", out double min);
                Checks.CanConvertToDouble(args[1], "RAND function requires a number argument", out double max);

                if (min >= max)
                {
                    throw new InvalidOperationException("The first argument (min) must be less than the second argument (max).");
                }

                return min + (random.NextDouble() * (max - min));
            }
            else
            {
                throw new InvalidOperationException("RAND function accepts zero, one, or two arguments.");
            }
        }
    }

}
