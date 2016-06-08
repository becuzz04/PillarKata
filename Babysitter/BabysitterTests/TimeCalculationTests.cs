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
    public class BabysittingRateCalculatorTests
    {
        [Test]
        public void GivenAWholeNumberOfHoursReturnTheHours()
        {
            Assert.AreEqual(5, BabysittingRateCalculator.CalculateHours(DateTime.Parse("1/1/2016 12:00 PM"), DateTime.Parse("1/1/2016 5:00 PM")));
        }

        [Test]
        public void GivenAFractionalNumberOfHoursReturnTheWholeHours()
        {
            Assert.AreEqual(5, BabysittingRateCalculator.CalculateHours(DateTime.Parse("1/1/2016 12:00 PM"), DateTime.Parse("1/1/2016 5:45 PM")));
        }

        [Test]
        public void EnsureBabysittingDoesNotStartBeforeFivePm()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => BabysittingRateCalculator.CalculatePayment(DateTime.Parse("1/1/2016 12:00 PM"), DateTime.Parse("1/1/2016 5:45 PM"), DateTime.Parse("1/1/2016 5:45 PM")));
        }

        [Test]
        public void EnsureBabysittingStartingAtFiveIsOk()
        {
            Assert.DoesNotThrow(() => BabysittingRateCalculator.CalculatePayment(DateTime.Parse("1/1/2016 5:00 PM"), DateTime.Parse("1/1/2016 5:45 PM"), DateTime.Parse("1/1/2016 5:45 PM")));
        }
    }
}
