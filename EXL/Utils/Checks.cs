using System.Globalization;

namespace EXL.Utils
{
    /// <summary>
    /// Provides utility methods for various checks and validations.
    /// </summary>
    public static class Checks
    {
        /// <summary>
        /// Attempts to convert the specified value to a double.
        /// </summary>
        /// <param name="value">The value to be converted to a double.</param>
        /// <param name="pattern">The string pattern to use in the exception message.</param>
        /// <param name="result">When this method returns, contains the double value equivalent to the value contained in <paramref name="value"/>, if the conversion succeeded, or zero if the conversion failed. This parameter is passed uninitialized.</param>
        /// <exception cref="InvalidCastException">Thrown when the provided value cannot be converted to a double.</exception>
        /// <remarks>
        /// This method uses <see cref="double.TryParse(string, NumberStyles, IFormatProvider, out double)"/> to attempt the conversion. If the conversion fails, an <see cref="InvalidCastException"/> is thrown.
        /// </remarks>
        public static void CanConvertToDouble(object value, string pattern, out double result)
        {
            var styles = NumberStyles.Float | NumberStyles.AllowThousands;
            var culture = CultureInfo.InvariantCulture;

            if (!double.TryParse(value.ToString(), styles, culture, out result))
            {
                throw new InvalidCastException(pattern);
            }
        }

        /// <summary>
        /// Tries to convert the specified value to a double.
        /// </summary>
        /// <param name="value">The value to be converted to a double.</param>
        /// <param name="result">When this method returns, contains the double value equivalent to the value contained in <paramref name="value"/>, if the conversion succeeded, or zero if the conversion failed. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the value was converted successfully; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// This method uses <see cref="double.TryParse(string, out double)"/> to attempt the conversion.
        /// </remarks>
        public static bool TryConvertToDouble(object value, out double result)
        {
            if (value == null)
            {
                result = 0;
                return false;
            }

            return double.TryParse(value.ToString(), NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out result);
        }
    }
}
