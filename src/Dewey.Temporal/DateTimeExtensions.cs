using System;

namespace Dewey.Temporal
{
    /// <summary>
    /// Extensions for the DateTime class
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Create a new DateTime that represents the Unix Epoch
        /// </summary>
        public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Determines if the DateTime year, month, and days are equal
        /// </summary>
        /// <param name="dateTime">The first DateTime value</param>
        /// <param name="other">The second DateTime value to compare</param>
        /// <returns>True if year, month and day are equal, False otherwise</returns>
        public static bool ThereAbouts(this DateTime dateTime, DateTime other) => (dateTime.Year == other.Year && dateTime.Month == other.Month && dateTime.Day == other.Day);

        /// <summary>
        /// Determines if the first DateTime comes after the second
        /// </summary>
        /// <param name="dateTime">The first DateTime value</param>
        /// <param name="other">The second DateTime value to compare</param>
        /// <returns>True if after, False otherwise</returns>
        public static bool After(this DateTime dateTime, DateTime other) => dateTime.CompareTo(other) > 0;

        /// <summary>
        /// Determines if the first DateTime comes before the second
        /// </summary>
        /// <param name="dateTime">The first DateTime value</param>
        /// <param name="other">The second DateTime value to compare</param>
        /// <returns>True if before, False otherwise</returns>
        public static bool Before(this DateTime dateTime, DateTime other) => dateTime.CompareTo(other) < 0;

        /// <summary>
        /// Remove the time from a DateTime
        /// </summary>
        /// <param name="dateTime">The DateTime from which to remove the time</param>
        /// <returns></returns>
        public static DateTime StripTime(this DateTime dateTime) => new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);

        /// <summary>
        /// Set the time for a DateTime from a DateTime
        /// </summary>
        /// <param name="dateTime">The DateTime for which to set the time</param>
        /// <param name="other">The DateTime from which the time is set</param>
        /// <returns>The new DateTime with the time set</returns>
        public static DateTime SetTime(this DateTime dateTime, DateTime other) => dateTime.SetTime(other.Hour, other.Minute, other.Second);

        /// <summary>
        /// Set the time for a DateTime from a Time
        /// </summary>
        /// <param name="dateTime">The DateTime for which to set the time</param>
        /// <param name="time">The Time from which the time is set</param>
        /// <returns>The new DateTime with the time set</returns>
        public static DateTime SetTime(this DateTime dateTime, Time time) => dateTime.SetTime(time.Hour, time.Minute, time.Second);

        /// <summary>
        /// Set the time for a DateTime from an hour, minute, and second
        /// </summary>
        /// <param name="dateTime">The DateTime for which to set the time</param>
        /// <param name="hour">The hour from which the time hour is set</param>
        /// <param name="minute">The minute from which the time minute is set</param>
        /// <param name="second">The second from which the time second is set</param>
        /// <returns>The new DateTime with the time set</returns>
        public static DateTime SetTime(this DateTime dateTime, int hour, int minute, int second) => new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, minute, second);

        /// <summary>
        /// Convert the DateTime object to a Unix time long value
        /// </summary>
        /// <param name="dateTime">The DateTime to convert</param>
        /// <returns>The Unix time long value</returns>
        public static long ToUnix(this DateTime dateTime) => (long)(dateTime - UnixEpoch).TotalMilliseconds;

        /// <summary>
        /// Create a DateTime from a Unix time long value
        /// </summary>
        /// <param name="unix">The Unix long time value from which to create the DateTime</param>
        /// <returns>The new DateTime from the Unix long value</returns>
        public static DateTime FromUnix(this long unix) => UnixEpoch.AddMilliseconds(unix);

        /// <summary>
        /// Merge a DateTime with a TimeSpan
        /// </summary>
        /// <param name="dateTime">The DateTime to merge in to</param>
        /// <param name="timeSpan">The TimeSpan to merge in to the DateTime</param>
        /// <returns>Te new DateTime merged with the TimeSpan</returns>
        public static DateTime Merge(this DateTime dateTime, TimeSpan timeSpan) => (dateTime.Date + timeSpan);

        /// <summary>
        /// Merge a DateTime with a Time
        /// </summary>
        /// <param name="dateTime">The DateTime to merge in to</param>
        /// <param name="time">The Time to merge in to the DateTime</param>
        /// <returns>Te new DateTime merged with the Time</returns>
        public static DateTime Merge(this DateTime dateTime, Time time) => (dateTime.Date + time.ToTimeSpan());

        /// <summary>
        /// Determines if the DateTime is a minimum DateTime value
        /// </summary>
        /// <param name="dateTime">The DateTime to check</param>
        /// <returns>True if is minimum valye, False otherwise</returns>
        public static bool IsMin(this DateTime dateTime) => (dateTime == DateTime.MinValue);

        /// <summary>
        /// Convert a DateTime to a Universal string
        /// </summary>
        /// <param name="dateTime">The DateTime to convert</param>
        /// <returns>A string formatted as a Universal date time</returns>
        public static string ToUniversalDateTimeString(this DateTime dateTime) => dateTime.ToString("yyyy-MM-ddTHH:mm:ss zzz");

        /// <summary>
        /// Add business days to a DateTime
        /// </summary>
        /// <param name="dateTime">The DateTime to which to add the business days</param>
        /// <param name="count">The number of business days to add</param>
        /// <returns>The new DateTime with the business days added</returns>
        public static DateTime AddBusinessDays(this DateTime dateTime, int count)
        {
            var direction = (count < 0) ? -1 : 1;

            while (count != 0) {
                dateTime = dateTime.AddDays(direction);

                if (dateTime.DayOfWeek != DayOfWeek.Saturday && dateTime.DayOfWeek != DayOfWeek.Sunday) {
                    count -= direction;
                }
            }

            return dateTime;
        }

        /// <summary>
        /// Determines the number of business days in the given month
        /// </summary>
        /// <param name="dateTime">The DateTime with the given month</param>
        /// <returns>The number of business days</returns>
        public static int BusinessDaysInMonth(this DateTime dateTime)
        {
            var year = dateTime.Year;
            var month = dateTime.Month;

            var result = 0;

            var daysInMonth = DateTime.DaysInMonth(year, month);
            var startDate = new DateTime(year, month, 1);
            var endDate = new DateTime(year, month, daysInMonth);

            for (var currentDate = startDate; currentDate < endDate; currentDate.AddDays(1)) {
                if (currentDate.DayOfWeek == DayOfWeek.Sunday || currentDate.DayOfWeek == DayOfWeek.Saturday) {
                    continue;
                }

                result++;
            }

            return result;
        }

        /// <summary>
        /// Get the number of business days that have passes since the beginning of the year
        /// </summary>
        /// <param name="dateTime">The DateTime to check against</param>
        /// <returns>The number of business days that have passes since the beginning of the year</returns>
        public static int BusinessDaysPassed(this DateTime dateTime)
        {
            var year = dateTime.Year;
            var month = dateTime.Month;
            var day = dateTime.Day;

            var result = 0;

            var startDate = new DateTime(year, 1, 1);
            var endDate = new DateTime(year, month, day);

            for (var currentDate = startDate; currentDate < endDate; currentDate.AddDays(1)) {
                if (currentDate.DayOfWeek == DayOfWeek.Sunday || currentDate.DayOfWeek == DayOfWeek.Saturday) {
                    continue;
                }

                result++;
            }

            return result;
        }

        /// <summary>
        /// Convert an int representation of a month to a month string
        /// </summary>
        /// <param name="month">The int representation of a month</param>
        /// <returns>The month string</returns>
        public static string ConvertMonthToString(this int month)
        {
            switch (month) {
                case 1:
                    return "January";

                case 2:
                    return "February";

                case 3:
                    return "March";

                case 4:
                    return "April";

                case 5:
                    return "May";

                case 6:
                    return "June";

                case 7:
                    return "July";

                case 8:
                    return "August";

                case 9:
                    return "September";

                case 10:
                    return "October";

                case 11:
                    return "November";

                case 12:
                    return "December";

                default:
                    return string.Empty;
            }
        }
    }
}
