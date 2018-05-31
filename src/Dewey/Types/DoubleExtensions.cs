using System;

namespace Dewey.Types
{
    /// <summary>
    /// Extension methods for Double type.
    /// </summary>
    public static class DoubleExtensions
    {
        public static bool IsAfter(this double value, double other) => (value > other);
        public static bool IsBefore(this double value, double other) => (value < other);

        public static decimal ToDecimal(this double value) => Convert.ToDecimal(value);
        public static int ToInt(this double value) => Convert.ToInt32(value);
        public static long ToLong(this double value) => Convert.ToInt64(value);

        public static bool IsZero(this double value) => (value == 0);

        public static double Round(this double value, int decimals = 2) => Math.Round(value, decimals);

        public static double Add(this double value, double arg) => (value + arg);
        public static double Add(this double value, int arg) => (value + arg.ToDouble());
        public static double Add(this double value, decimal arg) => (value + arg.ToDouble());
        public static double Add(this double value, long arg) => (value + arg.ToDouble());

        public static double Subtract(this double value, double arg) => (value - arg);
        public static double Subtract(this double value, int arg) => (value - arg.ToDouble());
        public static double Subtract(this double value, decimal arg) => (value - arg.ToDouble());
        public static double Subtract(this double value, long arg) => (value - arg.ToDouble());

        public static double Multiply(this double value, double arg) => (value * arg);
        public static double Multiply(this double value, int arg) => (value * arg.ToDouble());
        public static double Multiply(this double value, decimal arg) => (value * arg.ToDouble());
        public static double Multiply(this double value, long arg) => (value * arg.ToDouble());

        public static double Divide(this double value, double arg) => (value / arg);
        public static double Divide(this double value, int arg) => (value / arg.ToDouble());
        public static double Divide(this double value, decimal arg) => (value / arg.ToDouble());
        public static double Divide(this double value, long arg) => (value / arg.ToDouble());
    }
}
