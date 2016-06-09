using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babysitter
{
    public static class BabysittingRateCalculator
    {
        private const int FIVE_PM_HOUR = 17;
        private const int FOUR_AM_HOUR = 4;

        public static int CalculateHours(DateTime startTime, DateTime endTime)
        {
            TimeSpan timeDifference = endTime - startTime;
            return timeDifference.Hours;
        }

        public static decimal CalculatePayment(DateTime startTime, DateTime endTime, DateTime bedTime)
        {
            if (endTime < startTime)
            {
                throw new ArgumentException("Start time must be before end time.");
            }
            TimeSpan totalDifference = endTime - startTime;
            if (totalDifference.Days >= 1)
            {
                throw new ArgumentException("Time between start and end is too long.");
            }
            DateTime fiveOClockStartTime = startTime.Date.AddHours(FIVE_PM_HOUR);
            if (startTime < fiveOClockStartTime)
            {
                throw new ArgumentOutOfRangeException("Babysitting time cannot start before 5:00 PM.");
            }
            DateTime fourAmEndTime = endTime.Date.AddHours(FOUR_AM_HOUR);
            if (startTime.Date != endTime.Date && fourAmEndTime < endTime)
            {
                throw new ArgumentOutOfRangeException("End time cannot be after 4 AM.");
            }
            return 0m;
        }
    }
}
