using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class LeapYear
    {
        public static Boolean IsLeapYear(int year)
        {
            int leapYear = year;
            if (leapYear % 4 == 0 || leapYear % 100 == 0)
            {
                return true;
            }
            return false;
        }
    }
}
