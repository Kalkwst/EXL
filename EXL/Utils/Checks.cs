using System.Globalization;

namespace EXL.Utils
{
    /// <summary>
    /// Provides utility methods for various checks and validations.
    /// </summary>
    public static class Checks
    {
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

            return double.TryParse(NormalizeDecimal(value.ToString()), out result);
        }

        /// <summary>
        /// Normalizes the decimal separator in the specified string value.
        /// </summary>
        /// <param name="value">The string value to normalize.</param>
        /// <returns>A string with the normalized decimal separator.</returns>
        private static string NormalizeDecimal(string? value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return NumberFormatInfo.CurrentInfo.NumberDecimalSeparator == "."
                ? value.Replace(",", ".")
                : value.Replace(".", ",");
        }
    }
}
