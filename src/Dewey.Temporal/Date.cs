using Dewey.Types;
using System;

namespace Dewey.Temporal
{
    /// <summary>
    /// A Date object
    /// </summary>
    public class Date : IComparable
    {
        /// <summary>
        /// The month of the Date
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// The day of the Date
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// The year of the Date
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Construct a new Date
        /// </summary>
        public Date()
        {
            var today = new DateTime().Date;

            Month = today.Month;
            Day = today.Day;
            Year = today.Year;
        }

        /// <summary>
        /// Construct a new Date from year, month, and day
        /// </summary>
        public Date(int year, int month, int day)
        {
            if (year < 0) {
                throw new ArgumentException("Hour cannot be smaller than 0.");
            }

            if (month < 1) {
                throw new ArgumentException("Minute cannot be smaller than 1.");
            }

            if (day < 0) {
                throw new ArgumentException("Second cannot be smaller than 1.");
            }

            Year = year;
            Month = month;
            Day = day;
        }

        /// <summary>
        /// Construct a new Date from string
        /// </summary>
        public Date(string date)
        {
            if (date.IsEmpty()) {
                throw new ArgumentNullException("The 'date' parameter cannot be null.");
            }

            date = date.ToLower();

            DateTime dateTime;

            try {
                dateTime = DateTime.ParseExact(date, "yyyy/MM/dd", System.Globalization.CultureInfo.CurrentCulture);
            } catch {
                try {
                    dateTime = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                } catch {
                    try {
                        dateTime = DateTime.ParseExact(date, "yyyy/MM/dd H:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                    } catch {
                        try {
                            dateTime = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                        } catch {
                            throw new ArgumentException("Date is not in a valid format.");
                        }
                    }
                }
            }

            Day = dateTime.Day;
            Month = dateTime.Month;
            Year = dateTime.Year;
        }

        /// <summary>
        /// Construct a new Date from string and specify format
        /// </summary>
        public Date(string date, string format)
        {
            if (date.IsEmpty()) {
                throw new ArgumentNullException("The 'date' parameter cannot be null.");
            }

            date = date.ToLower();

            DateTime dateTime;

            try {
                dateTime = DateTime.ParseExact(date, format, System.Globalization.CultureInfo.CurrentCulture);
            } catch {
                throw new ArgumentException("Date is not in a valid format.");
            }

            Day = dateTime.Day;
            Month = dateTime.Month;
            Year = dateTime.Year;
        }

        /// <summary>
        /// Construct a new Date from a date time
        /// </summary>
        public Date(DateTime dateTime)
        {
            Day = dateTime.Day;
            Month = dateTime.Month;
            Year = dateTime.Year;
        }

        /// <summary>
        /// Add years to a Date
        /// </summary>
        /// <param name="years">The number of years to add</param>
        /// <returns>The new Date with years added</returns>
        public Date AddYears(int years)
        {
            var dateTime = ToDateTime().AddYears(years);

            Year = dateTime.Year;
            Month = dateTime.Month;
            Day = dateTime.Day;

            return this;
        }

        /// <summary>
        /// Add months to a Date
        /// </summary>
        /// <param name="months">The number of months to add</param>
        /// <returns>The new Date with months added</returns>
        public Date AddMonths(int months)
        {
            var dateTime = ToDateTime().AddMonths(months);

            Year = dateTime.Year;
            Month = dateTime.Month;
            Day = dateTime.Day;

            return this;
        }

        /// <summary>
        /// Add days to a Date
        /// </summary>
        /// <param name="days">The number of days to add</param>
        /// <returns>The new Date with days added</returns>
        public Date AddDays(int days)
        {
            var dateTime = ToDateTime().AddDays(days);

            Year = dateTime.Year;
            Month = dateTime.Month;
            Day = dateTime.Day;

            return this;
        }

        /// <summary>
        /// Convert to a DateTime
        /// </summary>
        /// <returns>The DateTime</returns>
        public DateTime ToDateTime() => new DateTime(Year, Month, Day, 0, 0, 0);

        /// <summary>
        /// Convert to a string
        /// </summary>
        /// <returns>The Date string</returns>
        public override string ToString() => ToDateTime().ToString("yyyy/MM/dd");

        /// <summary>
        /// Convert to a string from format
        /// </summary>
        /// <returns>The Date string</returns>
        public string ToString(string format) => ToDateTime().ToString(format);

        /// <summary>
        /// Compare the Date to an object using a DateTime compare
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>-1 if before, 0 if the same, 1 if above</returns>
        public int CompareTo(object obj) => DateTime.Compare(ToDateTime(), (DateTime)obj);

        /// <summary>
        /// Implicitly create a Date from a string
        /// </summary>
        /// <param name="date">The Date</param>
        public static implicit operator Date(string date) => new Date(date);

        /// <summary>
        /// Implicitly create a Date from a DateTime
        /// </summary>
        /// <param name="dateTime">The Date</param>
        public static implicit operator Date(DateTime dateTime) => new Date(dateTime);
    }
}
