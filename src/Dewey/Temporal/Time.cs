using Dewey.Types;
using System;
using System.Globalization;

namespace Dewey.Temporal
{
    public class Time
    {
        private DateTime _dateTime = DateTime.MinValue;

        public bool TwentyFourHour { get; set; }

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

        public Time()
        {
        }

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

        public Time(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public Time AddHours(int hours)
        {
            _dateTime.AddHours(hours);
            
            return this;
        }

        public Time AddMinutes(int minutes)
        {
            _dateTime.AddMinutes(minutes);

            return this;
        }

        public Time AddSeconds(double seconds)
        {
            _dateTime.AddSeconds(seconds);

            return this;
        }

        public Time AddMilliseconds(double milliseconds)
        {
            _dateTime.AddMilliseconds(milliseconds);

            return this;
        }

        public static implicit operator Time(string time)
        {
            return new Time(time);
        }

        public static implicit operator Time(DateTime DateTime)
        {
            return new Time(DateTime);
        }

        public DateTime ToDateTime()
        {
            return _dateTime;
        }

        public TimeSpan ToTimeSpan()
        {
            return _dateTime.TimeOfDay;
        }

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

        public string ToStringLong()
        {
            return _dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern);
        }

        public string ToStringShort()
        {
            return _dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern);
        }

        public string ToString(string format)
        {
            return _dateTime.ToString(format);
        }
    }
}
