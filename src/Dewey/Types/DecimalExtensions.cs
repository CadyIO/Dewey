using System;

namespace Dewey.Types
{
    /// <summary>
    /// Extension methods for Decimal type.
    /// </summary>
    public static class DecimalExtensions
    {
        /// <summary>
        /// Convert to a currency string.
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <example>One Dollar and Ten Cents.</example>
        /// <returns>A currency string.</returns>
        public static string NumberToCurrencyText(this decimal number)
        {
            // Round the value just in case the decimal value is longer than two digits.
            number = Math.Round(number, 2);

            // Divide the number into the whole and fractional part strings.
            var arrNumber = number.ToString().Split('.');

            // Get the whole number text.
            var wholePart = long.Parse(arrNumber[0]);
            var strWholePart = wholePart.NumberToText();

            // For amounts of zero dollars show 'No Dollars...' instead of 'Zero Dollars...'.
            var wordNumber = (wholePart == 0 ? "No" : strWholePart) + (wholePart == 1 ? " Dollar and " : " Dollars and ");

            // If the array has more than one element then there is a fractional part otherwise there isn't
            // just add 'No Cents' to the end.
            if (arrNumber.Length > 1) {
                // If the length of the fractional element is only 1, add a 0 so that the text returned isn't,
                // 'One', 'Two', etc but 'Ten', 'Twenty', etc.
                var fractionPart = long.Parse((arrNumber[1].Length == 1 ? arrNumber[1] + "0" : arrNumber[1]));
                var strFarctionPart = fractionPart.NumberToText();

                wordNumber += (fractionPart == 0 ? " No" : strFarctionPart) + (fractionPart == 1 ? " Cent" : " Cents");
            } else {
                wordNumber += "No Cents";
            }

            return wordNumber;
        }

        /// <summary>
        /// Determine whether the first decimal value is before the second decimal value.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="other">The value to compare.</param>
        /// <returns>True if before, false otherwise.</returns>
        public static bool IsBefore(this decimal value, decimal other) => (value < other);

        /// <summary>
        /// Determine whether the first decimal value is after the second decimal value.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="other">The value to compare.</param>
        /// <returns>True if after, false otherwise.</returns>
        public static bool IsAfter(this decimal value, decimal other) => (value > other);

        /// <summary>
        /// Converts the value of the specified object to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <returns>A 64-bit signed integer that is equivalent to value, or zero if value is null.</returns>
        public static int ToInt(this decimal value) => Convert.ToInt32(value);

        /// <summary>
        /// Converts the value of the specified decimal number to an equivalent double-precision floating-point number.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <returns>A double-precision floating-point number that is equivalent to value.</returns>
        public static double ToDouble(this decimal value) => Convert.ToDouble(value);

        /// <summary>
        /// Converts the value of the specified decimal number to an equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <returns>
        /// A value rounded to the nearest 64-bit signed integer. If value is halfway between
        /// two whole numbers, the even number is returned; that is, 4.5 is converted to
        /// 4, and 5.5 is converted to 6.</returns>
        public static long ToLong(this decimal value) => Convert.ToInt64(value);

        /// <summary>
        /// Check if the decimal value is zero.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>True if zero, false otherwise.</returns>
        public static bool IsZero(this decimal value) => (value == decimal.Zero);

        /// <summary>
        /// Round the decimal value to the provided number of decimal places.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="decimals">The number of decimal places.</param>
        /// <returns>The rounded value.</returns>
        public static decimal Round(this decimal value, int decimals = 2) => Math.Round(value, decimals);

        /// <summary>
        /// Add the value of two decimals.
        /// </summary>
        /// <param name="value">The decimal value to which to add.</param>
        /// <param name="arg">The decimal value to add.</param>
        /// <returns>The sum total of the added values.</returns>
        public static decimal Add(this decimal value, decimal arg) => (value + arg);
        public static decimal Add(this decimal value, int arg) => (value + arg.ToDecimal());
        public static decimal Add(this decimal value, double arg) => (value + arg.ToDecimal());
        public static decimal Add(this decimal value, long arg) => (value + arg.ToDecimal());

        public static decimal Subtract(this decimal value, decimal arg) => (value - arg);
        public static decimal Subtract(this decimal value, int arg) => (value - arg.ToDecimal());
        public static decimal Subtract(this decimal value, double arg) => (value - arg.ToDecimal());
        public static decimal Subtract(this decimal value, long arg) => (value - arg.ToDecimal());

        public static decimal Multiply(this decimal value, decimal arg) => (value * arg);
        public static decimal Multiply(this decimal value, int arg) => (value * arg.ToDecimal());
        public static decimal Multiply(this decimal value, double arg) => (value * arg.ToDecimal());
        public static decimal Multiply(this decimal value, long arg) => (value * arg.ToDecimal());

        public static decimal Divide(this decimal value, decimal arg) => (value / arg);
        public static decimal Divide(this decimal value, int arg) => (value / arg.ToDecimal());
        public static decimal Divide(this decimal value, double arg) => (value / arg.ToDecimal());
        public static decimal Divide(this decimal value, long arg) => (value / arg.ToDecimal());
    }
}
