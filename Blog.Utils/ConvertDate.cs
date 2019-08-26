using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Utils
{
    public class ConvertDate
    {
        private const uint SECOND = 1;
        private const uint MINUTE = 60 * SECOND;
        private const uint HOUR = 60 * MINUTE;
        private const uint DAY = 24 * HOUR;
        private const uint WEEK = 8 * DAY;

        public static string ConvertRelativeDate(DateTime youtDate)
        {
            var ts = new TimeSpan(DateTime.Now.Ticks - youtDate.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);
            string returnValue = "";

            if(delta <= MINUTE)
            {
                if(ts.Seconds == 1)
                {
                    returnValue =  "sekunde temu";
                }
                else if(ts.Seconds <=4)
                {
                    returnValue = ts.Seconds + " sekundy temu";
                }
                else
                {
                    returnValue = ts.Seconds + " sekund temu";
                }
            }
            if(delta <= HOUR)
            {
                if(ts.Minutes == 1)
                {
                    returnValue = "minute temu";
                }
                else if (ts.Minutes <= 4)
                {
                    returnValue = ts.Minutes + " minuty temu";
                }
                else
                {
                    returnValue = ts.Minutes + " minut temu";
                }
            }

            if(delta <= DAY)
            {
                if(ts.Hours == 1)
                {
                    returnValue = "godzinę temu";
                }
                else if(ts.Hours <= 4)
                {
                    returnValue = ts.Hours + " godziny temu";
                }
                else
                {
                    returnValue = ts.Hours + " godzin temu";
                }
            }

            if(delta <= WEEK)
            {
                if(ts.Days == 1)
                {
                    returnValue = "wczoraj";
                }
                else
                {
                    returnValue = ts.Days + " dni temu";
                }
            }

            if(delta > WEEK)
            {
                returnValue = youtDate.ToString();
            }

            return returnValue;
            
        }

    }
}
