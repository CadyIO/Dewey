namespace Dewey.Temporal
{
    public class DateRange
    {
        public Date Start { get; set; }
        public Date End { get; set; }

        public DateRange()
        {
            Start = new Date();
            End = new Date();
        }

        public DateRange(Date start, Date end)
        {
            Start = start;
            End = end;
        }

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

        public static implicit operator DateRange(string dateRange) => new DateRange(dateRange);

        public override string ToString() => string.Format("{0} - {1}", Start.ToString(), End.ToString());
    }
}
