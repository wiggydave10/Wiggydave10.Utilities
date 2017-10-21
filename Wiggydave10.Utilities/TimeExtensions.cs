using System;

namespace Wiggydave10.Utilities
{
    public static class TimeExtensions
    {
        public static decimal ToHours(this int seconds)
        {
            var secondsDecimal = (decimal)seconds;
            return Math.Round(secondsDecimal / 60 / 60, 2);
        }

        public static decimal ToNearestQuarterHour(this decimal hours)
        {
            return hours.ToNearestQuarterHour(0);
        }

        public static decimal ToNearestQuarterHour(this decimal hours, decimal minimumValue)
        {
            var result = Math.Round(hours * 4, MidpointRounding.ToEven) / 4;
            return result < minimumValue ? minimumValue : result;
        }
    }
}