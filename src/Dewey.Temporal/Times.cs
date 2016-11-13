namespace Dewey.Temporal
{
    /// <summary>
    /// A collection of static Time constructors
    /// </summary>
    public static class Times
    {
        /// <summary>
        /// A Time representing Midnight of a 12-hour clock
        /// </summary>
        public static Time Midnight => new Time();
        /// <summary>
        /// A Time representing 12:30am of a 12-hour clock
        /// </summary>
        public static Time MidnightThirty => new Time();
        /// <summary>
        /// A Time representing 1am of a 12-hour clock
        /// </summary>
        public static Time OneAM => new Time(1);
        /// <summary>
        /// A Time representing 1:30am of a 12-hour clock
        /// </summary>
        public static Time OneThirtyAM => new Time(1, 30);
        /// <summary>
        /// A Time representing 2am of a 12-hour clock
        /// </summary>
        public static Time TwoAM => new Time(2);
        /// <summary>
        /// A Time representing 2:30am of a 12-hour clock
        /// </summary>
        public static Time TwoThirtyAM => new Time(2, 30);
        /// <summary>
        /// A Time representing 3am of a 12-hour clock
        /// </summary>
        public static Time ThreeAM => new Time(3);
        /// <summary>
        /// A Time representing 3:30am of a 12-hour clock
        /// </summary>
        public static Time ThreeThirtyAM => new Time(3, 30);
        /// <summary>
        /// A Time representing 4am of a 12-hour clock
        /// </summary>
        public static Time FourAM => new Time(4);
        /// <summary>
        /// A Time representing 4:30am of a 12-hour clock
        /// </summary>
        public static Time FourThirtyAM => new Time(4, 30);
        /// <summary>
        /// A Time representing 5am of a 12-hour clock
        /// </summary>
        public static Time FiveAM => new Time(5);
        /// <summary>
        /// A Time representing 5:30am of a 12-hour clock
        /// </summary>
        public static Time FiveThirtyAM => new Time(5, 30);
        /// <summary>
        /// A Time representing 6am of a 12-hour clock
        /// </summary>
        public static Time SixAM => new Time(6);
        /// <summary>
        /// A Time representing 6:30am of a 12-hour clock
        /// </summary>
        public static Time SixThirtyAM => new Time(6, 30);
        /// <summary>
        /// A Time representing 7am of a 12-hour clock
        /// </summary>
        public static Time SevenAM => new Time(7);
        /// <summary>
        /// A Time representing 7:30am of a 12-hour clock
        /// </summary>
        public static Time SevenThirtyAM => new Time(7, 30);
        /// <summary>
        /// A Time representing 8am of a 12-hour clock
        /// </summary>
        public static Time EightAM => new Time(8);
        /// <summary>
        /// A Time representing 8:30am of a 12-hour clock
        /// </summary>
        public static Time EightThirtyAM => new Time(8, 30);
        /// <summary>
        /// A Time representing 9am of a 12-hour clock
        /// </summary>
        public static Time NineAM => new Time(9);
        /// <summary>
        /// A Time representing 9:30am of a 12-hour clock
        /// </summary>
        public static Time NineThirtyAM => new Time(9, 30);
        /// <summary>
        /// A Time representing 10am of a 12-hour clock
        /// </summary>
        public static Time TenAM => new Time(10);
        /// <summary>
        /// A Time representing 10:30am of a 12-hour clock
        /// </summary>
        public static Time TenThirtyAM => new Time(10, 30);
        /// <summary>
        /// A Time representing 11am of a 12-hour clock
        /// </summary>
        public static Time ElevenAM => new Time(11);
        /// <summary>
        /// A Time representing 11:30am of a 12-hour clock
        /// </summary>
        public static Time ElevenThirtyAM => new Time(11, 30);

        /// <summary>
        /// A Time representing noon of a 12-hour clock
        /// </summary>
        public static Time Noon => new Time(12, 0, 0, 0, false, true);
        /// <summary>
        /// A Time representing 12:30pm of a 12-hour clock
        /// </summary>
        public static Time NoonThirty => new Time(12, 30, 0, 0, false, true);
        /// <summary>
        /// A Time representing 1pm of a 12-hour clock
        /// </summary>
        public static Time OnePM => new Time(1, 0, 0, 0, false, true);
        /// <summary>
        /// A Time representing 1:30pm of a 12-hour clock
        /// </summary>
        public static Time OneThirtyPM => new Time(1, 30, 0, 0, false, true);
        /// <summary>
        /// A Time representing 2pm of a 12-hour clock
        /// </summary>
        public static Time TwoPM => new Time(2, 0, 0, 0, false, true);
        /// <summary>
        /// A Time representing 2:30pm of a 12-hour clock
        /// </summary>
        public static Time TwoThirtyPM => new Time(2, 30, 0, 0, false, true);
        /// <summary>
        /// A Time representing 3pm of a 12-hour clock
        /// </summary>
        public static Time ThreePM => new Time(3, 0, 0, 0, false, true);
        /// <summary>
        /// A Time representing 3:30pm of a 12-hour clock
        /// </summary>
        public static Time ThreeThirtyPM => new Time(3, 30, 0, 0, false, true);
        /// <summary>
        /// A Time representing 4pm of a 12-hour clock
        /// </summary>
        public static Time FourPM => new Time(4, 0, 0, 0, false, true);
        /// <summary>
        /// A Time representing 4:30pm of a 12-hour clock
        /// </summary>
        public static Time FourThirtyPM => new Time(4, 30, 0, 0, false, true);
        /// <summary>
        /// A Time representing 5pm of a 12-hour clock
        /// </summary>
        public static Time FivePM => new Time(5, 0, 0, 0, false, true);
        /// <summary>
        /// A Time representing 5:30pm of a 12-hour clock
        /// </summary>
        public static Time FiveThirtyPM => new Time(5, 30, 0, 0, false, true);
        /// <summary>
        /// A Time representing 6pm of a 12-hour clock
        /// </summary>
        public static Time SixPM => new Time(6, 0, 0, 0, false, true);
        /// <summary>
        /// A Time representing 6:30pm of a 12-hour clock
        /// </summary>
        public static Time SixThirtyPM => new Time(6, 30, 0, 0, false, true);
        /// <summary>
        /// A Time representing 7pm of a 12-hour clock
        /// </summary>
        public static Time SevenPM => new Time(7, 0, 0, 0, false, true);
        /// <summary>
        /// A Time representing 7:30pm of a 12-hour clock
        /// </summary>
        public static Time SevenThirtyPM => new Time(7, 30, 0, 0, false, true);
        /// <summary>
        /// A Time representing 8pm of a 12-hour clock
        /// </summary>
        public static Time EightPM => new Time(8, 0, 0, 0, false, true);
        /// <summary>
        /// A Time representing 8:30pm of a 12-hour clock
        /// </summary>
        public static Time EightThirtyPM => new Time(8, 30, 0, 0, false, true);
        /// <summary>
        /// A Time representing 9pm of a 12-hour clock
        /// </summary>
        public static Time NinePM => new Time(9, 0, 0, 0, false, true);
        /// <summary>
        /// A Time representing 9:30pm of a 12-hour clock
        /// </summary>
        public static Time NineThirtyPM => new Time(9, 30, 0, 0, false, true);
        /// <summary>
        /// A Time representing 10pm of a 12-hour clock
        /// </summary>
        public static Time TenPM => new Time(10, 0, 0, 0, false, true);
        /// <summary>
        /// A Time representing 10:30pm of a 12-hour clock
        /// </summary>
        public static Time TenThirtyPM => new Time(10, 30, 0, 0, false, true);
        /// <summary>
        /// A Time representing 11pm of a 12-hour clock
        /// </summary>
        public static Time ElevenPM => new Time(11, 0, 0, 0, false, true);
        /// <summary>
        /// A Time representing 11:30pm of a 12-hour clock
        /// </summary>
        public static Time ElevenThirtyPM => new Time(11, 30, 0, 0, false, true);

        /// <summary>
        /// A Time representing Midnight of a 24-hour clock
        /// </summary>
        public static Time Midnight24 => new Time(1, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 12:30am of a 24-hour clock
        /// </summary>
        public static Time MidnightThirty24 => new Time(1, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 1am of a 24-hour clock
        /// </summary>
        public static Time One24 => new Time(1, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 1:30am of a 24-hour clock
        /// </summary>
        public static Time OneThirty24 => new Time(1, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 2am of a 24-hour clock
        /// </summary>
        public static Time Two24 => new Time(2, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 2:30am of a 24-hour clock
        /// </summary>
        public static Time TwoThirty24 => new Time(2, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 3am of a 24-hour clock
        /// </summary>
        public static Time Three24 => new Time(3, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 3:30am of a 24-hour clock
        /// </summary>
        public static Time ThreeThirty24 => new Time(3, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 4am of a 24-hour clock
        /// </summary>
        public static Time Four24 => new Time(4, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 4:30am of a 24-hour clock
        /// </summary>
        public static Time FourThirty24 => new Time(4, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 5am of a 24-hour clock
        /// </summary>
        public static Time Five24 => new Time(5, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 5:30am of a 24-hour clock
        /// </summary>
        public static Time FiveThirty24 => new Time(5, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 6am of a 24-hour clock
        /// </summary>
        public static Time Six24 => new Time(6, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 6:30am of a 24-hour clock
        /// </summary>
        public static Time SixThirty24 => new Time(6, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 7am of a 24-hour clock
        /// </summary>
        public static Time Seven24 => new Time(7, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 7:30am of a 24-hour clock
        /// </summary>
        public static Time SevenThirty24 => new Time(7, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 8am of a 24-hour clock
        /// </summary>
        public static Time Eight24 => new Time(8, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 8:30am of a 24-hour clock
        /// </summary>
        public static Time EightThirty24 => new Time(8, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 9am of a 24-hour clock
        /// </summary>
        public static Time Nine24 => new Time(9, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 9:30am of a 24-hour clock
        /// </summary>
        public static Time NineThirty24 => new Time(9, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 10am of a 24-hour clock
        /// </summary>
        public static Time Ten24 => new Time(10, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 10:30am of a 24-hour clock
        /// </summary>
        public static Time TenThirty24 => new Time(10, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 11am of a 24-hour clock
        /// </summary>
        public static Time Eleven24 => new Time(11, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 11:30am of a 24-hour clock
        /// </summary>
        public static Time ElevenThirty24 => new Time(11, 30, 0, 0, true);
        /// <summary>
        /// A Time representing noon of a 12-hour clock
        /// </summary>
        public static Time Twelve24 => new Time(12, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 12:30pm of a 12-hour clock
        /// </summary>
        public static Time TwelveThirty24 => new Time(12, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 1pm of a 24-hour clock
        /// </summary>
        public static Time Thirteen24 => new Time(13, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 1:30pm of a 24-hour clock
        /// </summary>
        public static Time ThirteenThirty24 => new Time(13, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 2pm of a 24-hour clock
        /// </summary>
        public static Time Fourteen24 => new Time(14, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 2:30pm of a 24-hour clock
        /// </summary>
        public static Time FourteenThirty24 => new Time(14, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 3pm of a 24-hour clock
        /// </summary>
        public static Time Fifteen24 => new Time(15, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 3:30pm of a 24-hour clock
        /// </summary>
        public static Time FifteenThirty24 => new Time(15, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 4pm of a 24-hour clock
        /// </summary>
        public static Time Sixteen24 => new Time(16, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 4:30pm of a 24-hour clock
        /// </summary>
        public static Time SixteenThirty24 => new Time(16, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 5pm of a 24-hour clock
        /// </summary>
        public static Time Seventeen24 => new Time(17, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 5:30pm of a 24-hour clock
        /// </summary>
        public static Time SeventeenThirty24 => new Time(17, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 6pm of a 24-hour clock
        /// </summary>
        public static Time Eighteen24 => new Time(18, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 6:30pm of a 24-hour clock
        /// </summary>
        public static Time EighteenThirty24 => new Time(18, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 7pm of a 24-hour clock
        /// </summary>
        public static Time Nineteen24 => new Time(19, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 7:30pm of a 24-hour clock
        /// </summary>
        public static Time NineteenThirty24 => new Time(19, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 8pm of a 24-hour clock
        /// </summary>
        public static Time Twenty24 => new Time(20, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 8:30pm of a 24-hour clock
        /// </summary>
        public static Time TwentyThirty24 => new Time(20, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 9pm of a 24-hour clock
        /// </summary>
        public static Time TwentyOne24 => new Time(21, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 9:30pm of a 24-hour clock
        /// </summary>
        public static Time TwentyOneThirty24 => new Time(21, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 10pm of a 24-hour clock
        /// </summary>
        public static Time TentyTwo24 => new Time(22, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 10:30pm of a 24-hour clock
        /// </summary>
        public static Time TentyTwoThirty24 => new Time(22, 30, 0, 0, true);
        /// <summary>
        /// A Time representing 11pm of a 24-hour clock
        /// </summary>
        public static Time TwentyThree24 => new Time(23, 0, 0, 0, true);
        /// <summary>
        /// A Time representing 11:30pm of a 24-hour clock
        /// </summary>
        public static Time TwentyThreeThirty24 => new Time(23, 30, 0, 0, true);
    }
}
