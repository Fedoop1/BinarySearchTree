
using System;
using System.Globalization;

namespace TimeStruct
{
    public readonly struct Time : IEquatable<Time>
    {
        private const int HoursInDay = 24;
        private const int MinutesInHour = 60;

        public Time(int minutes)
            : this(0, minutes)
        {
        }

        public Time(int hours, int minutes) => (this.Hours, this.Minutes) = NormalizeTime(hours, minutes);

        public int Hours { get; }

        public int Minutes { get; }

        public new string ToString()
        {
            return $"{new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, this.Hours, this.Minutes, 0).ToString("HH:mm", CultureInfo.CurrentCulture)}";
        }

        public void Deconstruct(out int hours, out int minutes) => (hours, minutes) = (this.Hours, this.Minutes);

        private static (int Hours, int Minutes) NormalizeTime(int hours, int minutes)
        {
            int actualHours = (((minutes / MinutesInHour) % HoursInDay) + hours) % HoursInDay;
            int actualMinutes = minutes % MinutesInHour;

            if (actualMinutes < 0)
            {
                actualHours -= 1;
                actualMinutes = MinutesInHour - (-actualMinutes);
            }

            if (actualHours < 0)
            {
                actualHours = HoursInDay - (-actualHours);
            }

            return (actualHours, actualMinutes);
        }

        public bool Equals(Time other)  => this.GetHashCode() == other.GetHashCode();

        public override bool Equals(object obj) => obj switch
        {
            Time time => this.Equals(time),
            _ => false,
        };

        public override int GetHashCode() => this.Hours * 100 + this.Minutes;

        public static bool operator ==(Time left, Time right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Time left, Time right)
        {
            return !(left == right);
        }
    }
}
