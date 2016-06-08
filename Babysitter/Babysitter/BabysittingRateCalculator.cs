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
    }
}
