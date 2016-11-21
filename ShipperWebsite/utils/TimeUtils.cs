using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipperWebsite.utils
{
    public class TimeUtils
    {
        public static long ConvertToTimestamp(DateTime value)
        {
            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

            //return the total seconds (which is a UNIX timestamp)
            return (long)span.TotalSeconds;
        }

        public static DateTime ConvertTimestampToDateTime(long timestamp)
        {
            // Format our new DateTime object to start at the UNIX Epoch
            var dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

            // Add the timestamp (number of seconds since the Epoch) to be converted
            dateTime = dateTime.AddSeconds(timestamp);
            return dateTime;
        }
    }
}