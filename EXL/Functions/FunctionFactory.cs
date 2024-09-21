using EXL.Functions.Array;
using EXL.Functions.Mathematical;

namespace EXL.Functions
{
    public class FunctionFactory
    {
        private readonly Dictionary<string, IFunction> _functions = new Dictionary<string, IFunction>();

        public FunctionFactory()
        {
            this._functions["ABS"] = new AbsFunction();
            this._functions["ACOS"] = new AcosFunction();
            this._functions["ACOSH"] = new AcoshFunction();
            this._functions["ASIN"] = new AsinFunction();
            this._functions["ASINH"] = new AsinhFunction();
            this._functions["CEILING"] = new CeilingFunction();
            this._functions["COMBINATION"] = new CombinationFunction();
            this._functions["COS"] = new CosFunction();
            this._functions["DEGREES"] = new DegreesFunction();
            this._functions["EVEN"] = new EvenFunction();
            this._functions["EXP"] = new ExpFunction();
            this._functions["FLOOR"] = new FloorFunction();
            this._functions["LOG"] = new LogFunction();
            this._functions["MOD"] = new ModFunction();
            this._functions["ODD"] = new OddFunction();
            this._functions["POWER"] = new PowerFunction();
            this._functions["QUOTIENT"] = new QuotientFunction();
            this._functions["RAND"] = new RandFunction();
            this._functions["SIN"] = new SinFunction();

            this._functions["AVERAGE"] = new AverageFunction();
            this._functions["COUNT"] = new CountFunction();
            this._functions["MAX"] = new MaxFunction();
        }

        // Method to retrieve a function by name
        public IFunction GetFunction(string functionName)
        {
            if (this._functions.ContainsKey(functionName))
            {
                return this._functions[functionName];
            }
            throw new InvalidOperationException($"Unknown function: {functionName}");
        }

        // Method to register additional functions
        public void RegisterFunction(string name, IFunction function)
        {
            this._functions[name] = function;
        }
    }
}
