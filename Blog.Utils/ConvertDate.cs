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
        private const uint WEEK = 7 * DAY;

        public static string ConvertRelativeDate(DateTime youtDate)
        {
            var ts = new TimeSpan(DateTime.Now.Ticks - youtDate.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if(delta <= MINUTE)
            {
                if(ts.Seconds == 1)
                {
                    return "sekunde temu";
                }
                else
                {
                    return ts.Seconds + " sekund temu";
                }
            }
            if(delta <= HOUR)
            {
                if(ts.Minutes == 1)
                {
                    return "minute temu";
                }
                else
                {
                    return ts.Minutes + " minut temu";
                }
            }

            if(delta <= DAY)
            {
                if(ts.Hours == 1)
                {
                    return "godzinę temu";
                }
                else if(ts.Hours <= 4)
                {
                    return ts.Hours + " godziny temu";
                }
                else
                {
                    return ts.Hours + " godzin temu";
                }
            }

            if(delta <= WEEK)
            {
                if(ts.Days == 1)
                {
                    return "wczoraj";
                }
                else
                {
                    return ts.Days + " dni temu";
                }
            }

            return youtDate.ToString();
            
        }

    }
}
