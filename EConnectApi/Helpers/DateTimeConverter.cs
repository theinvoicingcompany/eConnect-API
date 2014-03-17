using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EConnectApi.Helpers
{
    static class DateTimeConverter
    {
        private static readonly DateTime EPoch = new DateTime(1970, 1, 1);

        /// <summary>
        /// Convert Java timestamp to DateTime
        /// Java timestamp is milliseconds past epoch
        /// </summary>
        /// <param name="javaTimeStamp"></param>
        /// <returns>Datetime</returns>
        public static DateTime ToDateTime(long javaTimeStamp)
        {
            return EPoch.AddMilliseconds(javaTimeStamp).ToLocalTime();
        }

        /// <summary>
        /// Convert DateTime to java timestamp
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>Time in milliseconds</returns>
        public static long ToJavaTimestamp(DateTime dt)
        {
            return (long)(dt.ToLocalTime() - EPoch.ToLocalTime()).TotalMilliseconds;
        }
    }
}
