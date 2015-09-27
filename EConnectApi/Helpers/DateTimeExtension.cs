using System;

namespace EConnectApi.Helpers
{
    internal static class DateTimeExtension
    {
        public static long ToJavaTimestamp(this DateTime dt)
        {
            return DateTimeConverter.ToJavaTimestamp(dt);
        }

        public static long ToReverseTimestamp(this DateTime dt)
        {
            return DateTimeConverter.ToReverseTimestamp(dt);
        }
    }
}