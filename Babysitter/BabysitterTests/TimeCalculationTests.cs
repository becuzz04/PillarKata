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
        public void EnsureHoursCalculationReturnsZeroIfEndIsAfterStart()
        {
            Assert.AreEqual(0, BabysittingRateCalculator.CalculateHours(DateTime.Parse("1/1/2016 10:00 PM"), DateTime.Parse("1/1/2016 5:45 PM")));
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

        [Test]
        public void EnsureEndTimeNoLaterThanFourAmNextDay()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => BabysittingRateCalculator.CalculatePayment(DateTime.Parse("1/1/2016 6:00 PM"), DateTime.Parse("1/2/2016 5:45 AM"), DateTime.Parse("1/1/2016 5:45 PM")));
        }

        [Test]
        public void EnsureEndTimeAtFourAmNextDayIsOk()
        {
            Assert.DoesNotThrow(() => BabysittingRateCalculator.CalculatePayment(DateTime.Parse("1/1/2016 6:00 PM"), DateTime.Parse("1/2/2016 4:00 AM"), DateTime.Parse("1/1/2016 5:45 PM")));
        }

        [Test]
        public void EnsureStartTimeBeforeEndTime()
        {
            Assert.Catch<ArgumentException>(() => BabysittingRateCalculator.CalculatePayment(DateTime.Parse("1/2/2016 6:00 PM"), DateTime.Parse("1/2/2016 4:00 AM"), DateTime.Parse("1/1/2016 5:45 PM")));
        }

        [Test]
        public void EnsureNightNotLongerThanADay()
        {
            Assert.Catch<ArgumentException>(() => BabysittingRateCalculator.CalculatePayment(DateTime.Parse("1/1/2016 6:00 PM"), DateTime.Parse("1/3/2016 4:00 AM"), DateTime.Parse("1/1/2016 5:45 PM")));
        }

        [Test]
        public void ValidateCalculationOfPaymentFromStartToBedtime()
        {
            Assert.AreEqual(60m, BabysittingRateCalculator.CalculatePayment(DateTime.Parse("1/1/2016 5:00 PM"), DateTime.Parse("1/1/2016 10:00 PM"), DateTime.Parse("1/1/2016 10:00 PM")));
        }

        [Test]
        public void ValidatePaymentWhenJobDoneBeforeBedtime()
        {
            Assert.AreEqual(36m, BabysittingRateCalculator.CalculatePayment(DateTime.Parse("1/1/2016 5:00 PM"), DateTime.Parse("1/1/2016 8:00 PM"), DateTime.Parse("1/1/2016 10:00 PM")));
        }

        [Test]
        public void ValidateCalculationOfPaymentFromBedtimeToMidnight()
        {
            Assert.AreEqual(76m, BabysittingRateCalculator.CalculatePayment(DateTime.Parse("1/1/2016 5:00 PM"), DateTime.Parse("1/2/2016 12:00 AM"), DateTime.Parse("1/1/2016 10:00 PM")));
        }

        [Test]
        public void ValidateCalculationOfPaymentFromBedtimeToMidnightWhenJobEndsBeforeMidnight()
        {
            Assert.AreEqual(68m, BabysittingRateCalculator.CalculatePayment(DateTime.Parse("1/1/2016 5:00 PM"), DateTime.Parse("1/1/2016 11:00 PM"), DateTime.Parse("1/1/2016 10:00 PM")));
        }

        [Test]
        public void ValidateCalculationOfPaymentFromMidnightToEnd()
        {
            Assert.AreEqual(140m, BabysittingRateCalculator.CalculatePayment(DateTime.Parse("1/1/2016 5:00 PM"), DateTime.Parse("1/2/2016 4:00 AM"), DateTime.Parse("1/1/2016 10:00 PM")));
        }
    }
}
