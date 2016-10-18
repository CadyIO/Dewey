using System;

namespace Dewey.Temporal
{
    public class DateTimeUtils
    {
        public static long GetValue(DateTime date) => (long)(date - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

        public static DateTime FromMillis(long ticks, bool ignoreError = true)
        {
            if (ticks == 0) {
                return DateTime.MinValue;
            }

            var posixTime = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);

            return posixTime.AddMilliseconds(ticks);
        }

        public static DateTime FromMillis(string ticks, bool ignoreError = true)
        {
            long millis;

            if (!long.TryParse(ticks, out millis)) {
                return DateTime.Now;
            }

            var posixTime = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);

            return posixTime.AddMilliseconds(millis);
        }

        public static DateTime Time(int hour, int minute, int second) => new DateTime(1970, 1, 1, hour, minute, second);

        public static DateTime Merge(DateTime dateTime, TimeSpan timeSpan) => (dateTime.Date + timeSpan);
    }
}