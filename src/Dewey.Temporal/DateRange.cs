namespace Dewey.Temporal
{
    /// <summary>
    /// A DateRange object that includes a start date and an end date
    /// </summary>
    public class DateRange
    {
        /// <summary>
        /// The start date of the DateRange
        /// </summary>
        public Date Start { get; set; }

        /// <summary>
        /// The end date of the DateRange
        /// </summary>
        public Date End { get; set; }

        /// <summary>
        /// Create a new DateRange
        /// </summary>
        public DateRange()
        {
            Start = new Date();
            End = new Date();
        }

        /// <summary>
        /// Create a new DateRange from a start date and end date
        /// </summary>
        public DateRange(Date start, Date end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// Create a new DateRange from a start date string and end date string
        /// </summary>
        public DateRange(string start, string end)
        {
            Start = new Date(start);
            End = new Date(end);
        }

        /// <summary>
        /// Creates a new DateRange
        /// </summary>
        /// <param name="dateRange">The DateRange value in the format of 'yyyy/MM/dd' - 'yyyy/MM/dd' (start - end)</param>
        public DateRange(string dateRange)
        {
            var split = dateRange.Split('-');

            Start = new Date(split[0].Trim());
            End = new Date(split[0].Trim());
        }

        /// <summary>
        /// Implicitly create a new DateRange from a string
        /// </summary>
        /// <param name="dateRange">The new DateRange</param>
        public static implicit operator DateRange(string dateRange) => new DateRange(dateRange);

        /// <summary>
        /// Create a string from a DateRange
        /// </summary>
        /// <returns>The DateRange string</returns>
        public override string ToString() => string.Format("{0} - {1}", Start.ToString(), End.ToString());
    }
}
