using EXL.Functions.Array;
using EXL.Functions.Mathematical;

namespace EXL.Functions
{
    public class FunctionFactory
    {
        private readonly Dictionary<string, IFunction> _functions = new Dictionary<string, IFunction>();

        public FunctionFactory()
        {
            _functions["ABS"] = new AbsFunction();
            _functions["ACOS"] = new AcosFunction();
            _functions["ACOSH"] = new AcoshFunction();
            _functions["ASIN"] = new AsinFunction();
            _functions["ASINH"] = new AsinhFunction();
            _functions["CEILING"] = new CeilingFunction();
            _functions["COMBINATION"] = new CombinationFunction();
            _functions["COS"] = new CosFunction();
            _functions["DEGREES"] = new DegreesFunction();
            _functions["EVEN"] = new EvenFunction();
            _functions["EXP"] = new ExpFunction();
            _functions["FLOOR"] = new FloorFunction();
            _functions["LOG"] = new LogFunction();
            _functions["MOD"] = new ModFunction();
            _functions["ODD"] = new OddFunction();
            _functions["POWER"] = new PowerFunction();
            _functions["QUOTIENT"] = new QuotientFunction();
            _functions["RAND"] = new RandFunction();
            _functions["SIN"] = new SinFunction();

            _functions["AVERAGE"] = new AverageFunction();
            _functions["COUNT"] = new CountFunction();
            _functions["MAX"] = new MaxFunction();
        }

        // Method to retrieve a function by name
        public IFunction GetFunction(string functionName)
        {
            if (_functions.ContainsKey(functionName))
            {
                return _functions[functionName];
            }
            throw new InvalidOperationException($"Unknown function: {functionName}");
        }

        // Method to register additional functions
        public void RegisterFunction(string name, IFunction function)
        {
            _functions[name] = function;
        }
    }
}
