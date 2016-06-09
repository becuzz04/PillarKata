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
        private const int MAX_HOURS_POSSIBLE = 11;

        private const decimal START_TO_BEDTIME_RATE = 12m;
        private const decimal BEDTIME_TO_MIDNIGHT_RATE = 8m;
        private const decimal MIDNIGHT_TO_FOUR_AM_RATE = 16m;

        public static int CalculateHours(DateTime startTime, DateTime endTime)
        {
            if (endTime < startTime)
            {
                return 0;
            }
            TimeSpan timeDifference = endTime - startTime;
            return (int)timeDifference.TotalHours;
        }

        public static decimal CalculatePayment(DateTime startTime, DateTime endTime, DateTime bedTime)
        {
            if (endTime < startTime)
            {
                throw new ArgumentException("Start time must be before end time.");
            }
            int hourDifference = CalculateHours(startTime, endTime);
            if (hourDifference > MAX_HOURS_POSSIBLE)
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

            int hoursFromStartToBedtime = CalculateHours(startTime, bedTime < endTime ? bedTime : endTime);

            DateTime midnight = startTime.Date.AddDays(1);
            int hoursFromBedtimeToMidnight = CalculateHours(bedTime, midnight < endTime ? midnight : endTime);
            return hoursFromStartToBedtime * START_TO_BEDTIME_RATE + hoursFromBedtimeToMidnight * BEDTIME_TO_MIDNIGHT_RATE;
        }
    }
}
