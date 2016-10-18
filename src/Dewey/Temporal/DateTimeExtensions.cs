using System;

namespace Dewey.Temporal
{
    public static class DateTimeExtensions
    {
        public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static bool ThereAbouts(this DateTime value, DateTime other) => (value.Year == other.Year && value.Month == other.Month && value.Day == other.Day);

        public static bool After(this DateTime value, DateTime other) => value.CompareTo(other) > 0;

        public static bool Before(this DateTime value, DateTime other) => value.CompareTo(other) < 0;

        public static DateTime StripTime(this DateTime value) => new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);

        public static DateTime SetTime(this DateTime value, DateTime other) => value.SetTime(other.Hour, other.Minute, other.Second);

        public static DateTime SetTime(this DateTime value, Time other) => value.SetTime(other.Hour, other.Minute, other.Second);

        public static DateTime SetTime(this DateTime value, int hour, int minute, int second) => new DateTime(value.Year, value.Month, value.Day, hour, minute, second);

        public static long ToUnix(this DateTime value) => (long)(value - UnixEpoch).TotalMilliseconds;

        public static DateTime FromUnix(this long unix) => UnixEpoch.AddMilliseconds(unix);

        public static DateTime Merge(this DateTime value, TimeSpan timeSpan) => (value.Date + timeSpan);

        public static DateTime Merge(this DateTime value, Time time) => (value.Date + time.ToTimeSpan());

        public static bool IsMin(this DateTime value) => (value == DateTime.MinValue);

        public static string ToUniversalDateTimeString(this DateTime value) => value.ToString("yyyy-MM-ddTHH:mm:ss zzz");

        public static DateTime AddBusinessDays(this DateTime value, int workingDays)
        {
            var direction = (workingDays < 0) ? -1 : 1;

            while (workingDays != 0) {
                value = value.AddDays(direction);

                if (value.DayOfWeek != DayOfWeek.Saturday && value.DayOfWeek != DayOfWeek.Sunday) {
                    workingDays -= direction;
                }
            }

            return value;
        }

        public static int BusinessDaysInMonth(this DateTime value)
        {
            var year = value.Year;
            var month = value.Month;

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

        public static int BusinessDaysPassed(this DateTime value)
        {
            var year = value.Year;
            var month = value.Month;
            var day = value.Day;

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
