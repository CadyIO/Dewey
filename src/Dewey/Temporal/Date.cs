using Dewey.Types;
using System;

namespace Dewey.Temporal
{
    public class Date : IComparable
    {
        public int Month { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }

        public Date()
        {
            var today = new DateTime().Date;

            Month = today.Month;
            Day = today.Day;
            Year = today.Year;
        }

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

        public Date(DateTime dateTime)
        {
            Day = dateTime.Day;
            Month = dateTime.Month;
            Year = dateTime.Year;
        }

        public Date AddYears(int years)
        {
            var dateTime = ToDateTime().AddYears(years);

            Year = dateTime.Year;
            Month = dateTime.Month;
            Day = dateTime.Day;

            return this;
        }

        public Date AddMonths(int months)
        {
            var dateTime = ToDateTime().AddMonths(months);

            Year = dateTime.Year;
            Month = dateTime.Month;
            Day = dateTime.Day;

            return this;
        }

        public Date AddDays(int days)
        {
            var dateTime = ToDateTime().AddDays(days);

            Year = dateTime.Year;
            Month = dateTime.Month;
            Day = dateTime.Day;

            return this;
        }

        public DateTime ToDateTime() => new DateTime(Year, Month, Day, 0, 0, 0);

        public override string ToString() => ToDateTime().ToString("yyyy/MM/dd");

        public string ToString(string format) => ToDateTime().ToString(format);

        public int CompareTo(object obj) => DateTime.Compare(ToDateTime(), (DateTime)obj);

        public static implicit operator Date(string date) => new Date(date);

        public static implicit operator Date(DateTime dateTime) => new Date(dateTime);
    }
}
