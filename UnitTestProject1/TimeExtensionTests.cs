using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Wiggydave10.Utilities.Tests
{
    [TestClass]
    public class TimeExtensionTests
    {
        [TestMethod]
        public void ToNearestQuarterHour_RoundDown()
        {
            var timeInHours = 0.1m;

            timeInHours = timeInHours.ToNearestQuarterHour();

            timeInHours.ShouldBe(0m);
        }

        [TestMethod]
        public void ToNearestQuarterHour_RoundUp()
        {
            var timeInHours = 0.46m;

            timeInHours = timeInHours.ToNearestQuarterHour();

            timeInHours.ShouldBe(0.5m);
        }

        [TestMethod]
        public void ToNearestQuarterHourMinimum_SetToMinimum()
        {
            var timeInHours = 0.1m;

            timeInHours = timeInHours.ToNearestQuarterHour(0.25m);

            timeInHours.ShouldBe(0.25m);
        }

        [TestMethod]
        public void ToNearestQuarterHourMinimum_RoundDown()
        {
            var timeInHours = 0.3m;

            timeInHours = timeInHours.ToNearestQuarterHour(0.25m);

            timeInHours.ShouldBe(0.25m);
        }

        [TestMethod]
        public void ToNearestQuarterHourMinimum_RoundUp()
        {
            var timeInHours = 0.46m;

            timeInHours = timeInHours.ToNearestQuarterHour(0.25m);

            timeInHours.ShouldBe(0.5m);
        }
    }
}
