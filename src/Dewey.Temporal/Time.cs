using Dewey.Types;
using System;
using System.Globalization;

namespace Dewey.Temporal
{
    /// <summary>
    /// A Time object
    /// </summary>
    public class Time
    {
        /// <summary>
        /// The internal DateTime value to hold the time
        /// </summary>
        private DateTime _dateTime = DateTime.MinValue;

        /// <summary>
        /// True if Time is 24-hour format, False for 12-hour format
        /// </summary>
        public bool TwentyFourHour { get; set; }

        /// <summary>
        /// The hour of the Time
        /// </summary>
        public int Hour
        {
            get
            {
                return _dateTime.Hour;
            }
            set
            {
                var timeSpan = new TimeSpan(0, value, _dateTime.Minute, _dateTime.Second, _dateTime.Millisecond);

                _dateTime = _dateTime.Date + timeSpan;
            }
        }

        /// <summary>
        /// The minute of the Time
        /// </summary>
        public int Minute
        {
            get
            {
                return _dateTime.Minute;
            }
            set
            {
                var timeSpan = new TimeSpan(0, _dateTime.Hour, value, _dateTime.Second, _dateTime.Millisecond);

                _dateTime = _dateTime.Date + timeSpan;
            }
        }

        /// <summary>
        /// The second of the Time
        /// </summary>
        public int Second
        {
            get
            {
                return _dateTime.Second;
            }
            set
            {
                var timeSpan = new TimeSpan(0, _dateTime.Hour, _dateTime.Minute, value, _dateTime.Millisecond);

                _dateTime = _dateTime.Date + timeSpan;
            }
        }

        /// <summary>
        /// The millisecond of the Time
        /// </summary>
        public int Millisecond
        {
            get
            {
                return _dateTime.Millisecond;
            }
            set
            {
                var timeSpan = new TimeSpan(0, _dateTime.Hour, _dateTime.Minute, _dateTime.Second, value);

                _dateTime = _dateTime.Date + timeSpan;
            }
        }
        
        /// <summary>
        /// The default constructor
        /// </summary>
        public Time()
        {
        }

        /// <summary>
        /// The constructor with values
        /// </summary>
        /// <param name="hour">The hour of the Time</param>
        /// <param name="minute">The minute of the Time</param>
        /// <param name="second">The second of the Time</param>
        /// <param name="millisecond">The millisecond of the Time</param>
        /// <param name="twentyFourHour">True if Time is 24-hour format, False for 12-hour format</param>
        /// <param name="pm">True if 12-hour clock and Time is PM, False if 12-hour clock and Time is AM, ignored if 24-hour clock</param>
        public Time(int hour = 0, int minute = 0, int second = 0, int millisecond = 0, bool twentyFourHour = false, bool pm = false)
        {
            if (hour < 0) {
                throw new ArgumentException("Hour cannot be smaller than 0.");
            }

            if (minute < 0) {
                throw new ArgumentException("Minute cannot be smaller than 0.");
            }

            if (second < 0) {
                throw new ArgumentException("Second cannot be smaller than 0.");
            }

            if (millisecond < 0) {
                throw new ArgumentException("Millisecond cannot be smaller than 0.");
            }

            if (twentyFourHour) {
                if (hour > 24) {
                    throw new ArgumentException("Hour cannot be larger than 23 on a twenty-four hour clock.");
                }
            } else {
                if (hour > 12) {
                    throw new ArgumentException("Hour cannot be larger than 11 on a twelve hour clock.");
                }
            }

            if (minute > 59) {
                throw new ArgumentException("Minute cannot be larger than 59.");
            }

            if (second > 59) {
                throw new ArgumentException("Second cannot be larger than 59.");
            }

            if (millisecond > 59) {
                throw new ArgumentException("Millisecond cannot be larger than 59.");
            }

            TwentyFourHour = twentyFourHour;

            try {
                var timeSpan = new TimeSpan(0, hour, minute, second, millisecond);

                _dateTime = _dateTime.Date + timeSpan;
            } catch {
                throw new ArgumentException("Time is not in a valid format.");
            }
        }

        /// <summary>
        /// A constructor from a string representation
        /// </summary>
        /// <param name="time">The string representation</param>
        /// <example>h:mm tt</example>
        /// <example>hh:mm tt</example>
        /// <example>H:mm</example>
        /// <example>HH:mm</example>
        public Time(string time)
        {
            if (time.IsEmpty()) {
                throw new ArgumentNullException("The 'time' parameter cannot be null.");
            }

            time = time.ToLower();

            try {
                _dateTime = DateTime.ParseExact(time, "h:mm tt", System.Globalization.CultureInfo.CurrentCulture);
            } catch {
                try {
                    _dateTime = DateTime.ParseExact(time, "hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                } catch {
                    try {
                        _dateTime = DateTime.ParseExact(time, "H:mm", System.Globalization.CultureInfo.CurrentCulture);
                    } catch {
                        try {
                        _dateTime = DateTime.ParseExact(time, "HH:mm", System.Globalization.CultureInfo.CurrentCulture);
                    } catch {
                        throw new ArgumentException("Time is not in a valid format.");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// A constructor from a string representation and specified format
        /// </summary>
        /// <param name="time">The string representation</param>
        /// <param name="format">The format of the string representation</param>
        public Time(string time, string format)
        {
            if (time.IsEmpty()) {
                throw new ArgumentNullException("The 'time' parameter cannot be null.");
            }

            time = time.ToLower();

            try {
                _dateTime = DateTime.ParseExact(time, format, System.Globalization.CultureInfo.CurrentCulture);
            } catch {
                throw new ArgumentException("Time is not in a valid format.");
            }
        }

        /// <summary>
        /// A constructor from a DateTime
        /// </summary>
        /// <param name="dateTime">The DateTime</param>
        public Time(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        /// <summary>
        /// Add hours to a Time
        /// </summary>
        /// <param name="hours">The number of hours to add</param>
        /// <returns>The new Time</returns>
        public Time AddHours(int hours)
        {
            _dateTime.AddHours(hours);
            
            return this;
        }

        /// <summary>
        /// Add minutes to a time
        /// </summary>
        /// <param name="minutes">The number of minutes to add</param>
        /// <returns>The new time</returns>
        public Time AddMinutes(int minutes)
        {
            _dateTime.AddMinutes(minutes);

            return this;
        }

        /// <summary>
        /// Add seconds to a Time
        /// </summary>
        /// <param name="seconds">The number of seconds to add</param>
        /// <returns>The new Time</returns>
        public Time AddSeconds(double seconds)
        {
            _dateTime.AddSeconds(seconds);

            return this;
        }

        /// <summary>
        /// Add milliseconds to a Time
        /// </summary>
        /// <param name="milliseconds">The number of milliseconds to add</param>
        /// <returns>The new Time</returns>
        public Time AddMilliseconds(double milliseconds)
        {
            _dateTime.AddMilliseconds(milliseconds);

            return this;
        }

        /// <summary>
        /// Implicitly create a Time from a string representation
        /// </summary>
        /// <param name="time">The Time</param>
        public static implicit operator Time(string time) => new Time(time);

        /// <summary>
        /// Implicitly create a Time from a Datetime representation
        /// </summary>
        /// <param name="dateTime">The DateTime</param>
        public static implicit operator Time(DateTime dateTime) => new Time(dateTime);

        /// <summary>
        /// Convert a Time to a DateTime
        /// </summary>
        /// <returns>The DateTime</returns>
        public DateTime ToDateTime() => _dateTime;

        /// <summary>
        /// Convert a Time to a TimeSpan
        /// </summary>
        /// <returns>The TimeSpan</returns>
        public TimeSpan ToTimeSpan() => _dateTime.TimeOfDay;

        /// <summary>
        /// Convert a Time to a string representation
        /// </summary>
        /// <returns>The DateTime string</returns>
        public override string ToString()
        {
            try {
                if (TwentyFourHour) {
                    return _dateTime.ToString("HH:mm:ss");
                } else {
                    return _dateTime.ToString("hh:mm:ss tt");
                }
            } catch {
                throw new Exception("Time is not valid");
            }
        }

        /// <summary>
        /// Convert a Time to a long string representation (CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern)
        /// </summary>
        /// <returns>The DateTime string</returns>
        public string ToStringLong() => _dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern);

        /// <summary>
        /// Convert a Time to a long string representation (CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern)
        /// </summary>
        /// <returns>The DateTime string</returns>
        public string ToStringShort() => _dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern);

        /// <summary>
        /// Convert a Time to a string representation of a provided format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The DateTime string</returns>
        public string ToString(string format) => _dateTime.ToString(format);
    }
}
