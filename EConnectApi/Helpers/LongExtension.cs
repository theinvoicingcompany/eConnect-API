using System;

namespace EConnectApi.Helpers
{
    internal static class LongExtension
    {
        public static DateTime ToDateTime(this long stamp)
        {
            return DateTimeConverter.ToDateTime(stamp);
        }

        public static DateTime ToDateTimeFromReverseTimestamp(this long javaTimeStamp)
        {
            return ToDateTime(long.MaxValue - javaTimeStamp);
        }
    }
}