using System;

namespace Dewey.Temporal
{
    /// <summary>
    /// A collection of DateTime utilities
    /// </summary>
    public class DateTimeUtils
    {
        /// <summary>
        /// Get the UTC long value of a DateTime
        /// </summary>
        /// <param name="dateTime">The DateTime for which to get the UTC long value</param>
        /// <returns>The UTC long value</returns>
        public static long GetUtcValue(DateTime dateTime) => (long)(dateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

        /// <summary>
        /// Get a DateTime from milliseconds (ticks)
        /// </summary>
        /// <param name="ticks">The number of ticks from which to get the DateTime</param>
        /// <returns>The DateTime</returns>
        public static DateTime FromMillis(double ticks)
        {
            if (ticks == 0) {
                return DateTime.MinValue;
            }

            var posixTime = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);

            return posixTime.AddMilliseconds(ticks);
        }

        /// <summary>
        /// Get a DateTime from milliseconds (ticks)
        /// </summary>
        /// <param name="ticks">The number of ticks from which to get the DateTime</param>
        /// <returns>The DateTime</returns>
        public static DateTime FromMillis(long ticks)
        {
            if (ticks == 0) {
                return DateTime.MinValue;
            }

            var posixTime = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);

            return posixTime.AddMilliseconds(ticks);
        }

        /// <summary>
        /// Get a DateTime from milliseconds (ticks)
        /// </summary>
        /// <param name="ticks">The number of ticks from which to get the DateTime</param>
        /// <returns>The DateTime</returns>
        public static DateTime FromMillis(string ticks)
        {
            long millis;

            if (!long.TryParse(ticks, out millis)) {
                return DateTime.Now;
            }

            var posixTime = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);

            return posixTime.AddMilliseconds(millis);
        }

        /// <summary>
        /// Merge a DateTime with a TimeSpan
        /// </summary>
        /// <param name="dateTime">The DateTime to merge in to</param>
        /// <param name="timeSpan">The TimeSpan to merge in to the DateTime</param>
        /// <returns>Te new DateTime merged with the TimeSpan</returns>
        public static DateTime Merge(DateTime dateTime, TimeSpan timeSpan) => (dateTime.Date + timeSpan);
    }
}