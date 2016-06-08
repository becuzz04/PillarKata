using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babysitter
{
    public static class BabysittingRateCalculator
    {
        public static int CalculateHours(DateTime startTime, DateTime endTime)
        {
            TimeSpan timeDifference = endTime - startTime;
            return timeDifference.Hours;
        }

        public static decimal CalculatePayment(DateTime startTime, DateTime endTime, DateTime bedTime)
        {
            if (startTime.Hour < 17)
            {
                throw new ArgumentOutOfRangeException("Babysitting time cannot start before 5:00 PM.");
            }
            return 0m;
        }
    }
}
