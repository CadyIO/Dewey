using System;

namespace Dewey.Temporal
{
    /// <summary>
    /// Represents a Quarter of a year
    /// </summary>
    public class Quarter
    {
        /// <summary>
        /// The string representation of the Quarter
        /// Defaults to 'One'
        /// </summary>
        private string _quarter = "One";

        /// <summary>
        /// The current year
        /// </summary>
        private int _year = DateTime.UtcNow.Year;

        /// <summary>
        /// The internal DateRange of the Quarter
        /// </summary>
        private DateRange _dateRange;

        /// <summary>
        /// The start Date of the Quarter
        /// </summary>
        public Date Start => _dateRange.Start;

        /// <summary>
        /// The end Date of the Quarter
        /// </summary>
        public Date End => _dateRange.End;
        
        /// <summary>
        /// Private constructor so it cannot be instantiated - Use static instead
        /// </summary>
        private Quarter()
        {
            // Prevent Constructor
        }

        /// <summary>
        /// Private constructor with properties so it cannot be instantiated - Use static instead
        /// </summary>
        private Quarter(string quarter, Date start, Date end)
        {
            _quarter = quarter;
            _dateRange = new DateRange(start, end);
        }

        /// <summary>
        /// The year of the Quarter
        /// </summary>
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;

                _dateRange.Start.Year = _year;
                _dateRange.End.Year = _year;
            }
        }

        /// <summary>
        /// Get the first Quarter
        /// </summary>
        public static Quarter One => new Quarter("One", new Date(DateTime.UtcNow.Year, 1, 1), new Date(DateTime.UtcNow.Year, 4, 1));

        /// <summary>
        /// Get the second Quarter
        /// </summary>
        public static Quarter Two => new Quarter("Two", new Date(DateTime.UtcNow.Year, 4, 1), new Date(DateTime.UtcNow.Year, 7, 1));

        /// <summary>
        /// Get the third Quarter
        /// </summary>
        public static Quarter Three => new Quarter("Three", new Date(DateTime.UtcNow.Year, 7, 1), new Date(DateTime.UtcNow.Year, 10, 1));

        /// <summary>
        /// Get the fourth Quarter
        /// </summary>
        public static Quarter Four => new Quarter("Four", new Date(DateTime.UtcNow.Year, 10, 1), new Date(DateTime.UtcNow.Year + 1, 1, 1));

        /// <summary>
        /// Create a Quarter from a string
        /// Returns 'One' if no other is matched
        /// </summary>
        /// <param name="quarter">The string representation of the Quarter</param>
        public static implicit operator Quarter(string quarter)
        {
            switch(quarter) {
                case "Four":
                    return Four;
                case "Two":
                    return Two;
                case "Three":
                    return Three;
                default:
                    return One;
            }
        }

        /// <summary>
        /// Get the string representation of the Quarter
        /// </summary>
        /// <returns>The string representation of the Quarter</returns>
        public override string ToString() => _quarter;

        /// <summary>
        /// Cast the quarter to a date range string
        /// </summary>
        /// <returns>The date range that represents the Quarter</returns>
        public string ToDateRangeString() => string.Format("{0} - {1}", Start.ToString(), End.ToString());
    }
}
