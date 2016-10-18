using System;

namespace Dewey.Types
{
    /// <summary>
    /// Extension methods for Integer type
    /// </summary>
    public static class IntExtensions
    {
        public static bool IsAfter(this int value, int other) => (value > other);
        public static bool IsBefore(this int value, int other) => (value < other);

        public static decimal ToDecimal(this int value) => Convert.ToDecimal(value);
        public static double ToDouble(this int value) => Convert.ToDouble(value);
        public static long ToLong(this int value) => Convert.ToInt64(value);

        public static bool IsZero(this int value) => (value == 0);

        public static double Round(this int value, int decimals = 2) => Math.Round(value.ToDouble(), decimals).ToInt();

        public static int Add(this int value, int arg) => (value + arg);
        public static int Add(this int value, decimal arg) => (value + arg.ToInt());
        public static int Add(this int value, double arg) => (value + arg.ToInt());
        public static int Add(this int value, long arg) => (value + arg.ToInt());

        public static int Subtract(this int value, int arg) => (value - arg);
        public static int Subtract(this int value, decimal arg) => (value - arg.ToInt());
        public static int Subtract(this int value, double arg) => (value - arg.ToInt());
        public static int Subtract(this int value, long arg) => (value - arg.ToInt());

        public static int Multiply(this int value, int arg) => (value * arg);
        public static int Multiply(this int value, decimal arg) => (value * arg.ToInt());
        public static int Multiply(this int value, double arg) => (value * arg.ToInt());
        public static int Multiply(this int value, long arg) => (value * arg.ToInt());

        public static int Divide(this int value, int arg) => (value / arg);
        public static int Divide(this int value, decimal arg) => (value / arg.ToInt());
        public static int Divide(this int value, double arg) => (value / arg.ToInt());
        public static int Divide(this int value, long arg) => (value / arg.ToInt());

        public static string FileSizeToString(this int value)
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
    }
}
