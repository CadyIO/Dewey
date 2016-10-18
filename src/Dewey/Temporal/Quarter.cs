using System;

namespace Dewey.Temporal
{
    public class Quarter
    {
        private string _quarter = "One";

        private int _year = DateTime.UtcNow.Year;

        private DateRange _dateRange;

        public Date Start => _dateRange.Start;
        public Date End => _dateRange.End;
        
        private Quarter()
        {
            // Prevent Constructor
        }

        private Quarter(string quarter, Date start, Date end)
        {
            _quarter = quarter;
            _dateRange = new DateRange(start, end);
        }

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

        public static Quarter One => new Quarter("One", new Date(DateTime.UtcNow.Year, 1, 1), new Date(DateTime.UtcNow.Year, 4, 1));
        public static Quarter Two => new Quarter("Two", new Date(DateTime.UtcNow.Year, 4, 1), new Date(DateTime.UtcNow.Year, 7, 1));
        public static Quarter Three => new Quarter("Three", new Date(DateTime.UtcNow.Year, 7, 1), new Date(DateTime.UtcNow.Year, 10, 1));
        public static Quarter Four => new Quarter("Four", new Date(DateTime.UtcNow.Year, 10, 1), new Date(DateTime.UtcNow.Year + 1, 1, 1));
        
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

        public override string ToString() => _quarter;

        public string ToDateRangeString() => string.Format("{0} - {1}", Start.ToString(), End.ToString());
    }
}
