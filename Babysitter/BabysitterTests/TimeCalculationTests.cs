using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Babysitter;
using NUnit.Framework;

namespace BabysitterTests
{
    [TestFixture]
    public class TimeCalculationTests
    {
        [Test]
        public void GivenAWholeNumberOfHoursReturnTheHours()
        {
            Assert.AreEqual(5, TimeCalculator.CalculateHours(DateTime.Parse("1/1/2016 12:00 PM"), DateTime.Parse("1/1/2016 5:00 PM")));
        }

        [Test]
        public void GivenAFractionalNumberOfHoursReturnTheWholeHours()
        {
            Assert.AreEqual(5, TimeCalculator.CalculateHours(DateTime.Parse("1/1/2016 12:00 PM"), DateTime.Parse("1/1/2016 5:45 PM")));
        }
    }
}
