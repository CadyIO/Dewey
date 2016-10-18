using System;
using System.Text;

namespace Dewey.Types
{
    /// <summary>
    /// Extension methods for Long type
    /// </summary>
    public static class LongExtensions
    {
        public static bool IsAfter(this long value, long other) => (value > other);
        public static bool IsBefore(this long value, long other) => (value < other);

        public static decimal ToDecimal(this long value) => Convert.ToDecimal(value);
        public static double ToDouble(this long value) => Convert.ToDouble(value);
        public static int ToInt(this long value) => Convert.ToInt32(value);

        public static bool IsZero(this long value) => (value == 0);

        public static long Round(this long value, int decimals = 2) => Math.Round(value.ToDouble(), decimals).ToLong();

        public static long Add(this long value, long arg) => (value + arg);
        public static long Add(this long value, int arg) => (value + arg.ToLong());
        public static long Add(this long value, decimal arg) => (value + arg.ToLong());
        public static long Add(this long value, double arg) => (value + arg.ToLong());

        public static long Subtract(this long value, long arg) => (value - arg);
        public static long Subtract(this long value, decimal arg) => (value - arg.ToLong());
        public static long Subtract(this long value, double arg) => (value - arg.ToLong());
        public static long Subtract(this long value, int arg) => (value - arg.ToLong());

        public static long Multiply(this long value, long arg) => (value * arg);
        public static long Multiply(this long value, decimal arg) => (value * arg.ToLong());
        public static long Multiply(this long value, double arg) => (value * arg.ToLong());
        public static long Multiply(this long value, int arg) => (value * arg.ToLong());

        public static long Divide(this long value, long arg) => (value / arg);
        public static long Divide(this long value, decimal arg) => (value / arg.ToLong());
        public static long Divide(this long value, double arg) => (value / arg.ToLong());
        public static long Divide(this long value, int arg) => (value / arg.ToLong());

        /// <summary>
        /// Convert a file size long value to a readable string
        /// </summary>
        /// <param name="value">The number to convert</param>
        /// <example>100 MB</example>
        /// <returns>A readable string</returns>
        public static string FileSizeToString(this long value)
        {
            float amount = value;

            if (amount < 1024) {
                return value + " Bytes";
            }

            amount /= 1024;

            if (amount < 1024) {
                return amount.ToString("N2") + " KB";
            }

            amount /= 1024;

            return amount.ToString("N2") + " MB";
        }

        /// <summary>
        /// Convert to number string
        /// </summary>
        /// <param name="number">The number to convert</param>
        /// <example>Two Thousand</example>
        /// <returns>A number string</returns>
        public static string NumberToText(this long number)
        {
            StringBuilder wordNumber = new StringBuilder();

            var powers = new[] { "Thousand ", "Million ", "Billion " };
            var tens = new[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            var ones = new[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

            if (number == 0) { return "Zero"; }
            if (number < 0) {
                wordNumber.Append("Negative ");
                number = -number;
            }

            var groupedNumber = new long[] { 0, 0, 0, 0 };
            var groupIndex = 0;

            while (number > 0) {
                groupedNumber[groupIndex++] = number % 1000;
                number /= 1000;
            }

            for (int i = 3; i >= 0; i--) {
                var group = groupedNumber[i];

                if (group >= 100) {
                    wordNumber.Append(ones[group / 100 - 1] + " Hundred ");
                    group %= 100;

                    if (group == 0 && i > 0)
                        wordNumber.Append(powers[i - 1]);
                }

                if (group >= 20) {
                    if ((group % 10) != 0)
                        wordNumber.Append(tens[group / 10 - 2] + " " + ones[group % 10 - 1] + " ");
                    else
                        wordNumber.Append(tens[group / 10 - 2] + " ");
                } else if (group > 0)
                    wordNumber.Append(ones[group - 1] + " ");

                if (group != 0 && i > 0)
                    wordNumber.Append(powers[i - 1]);
            }

            return wordNumber.ToString().Trim();
        }
    }
}
