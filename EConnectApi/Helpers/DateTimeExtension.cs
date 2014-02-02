using System;

namespace EConnectApi.Helpers
{
    internal static class DateTimeExtension
    {
        public static double ToJavaTimestamp(this DateTime dt)
        {
            return DateTimeConverter.ToJavaTimestamp(dt);
        }
    }
}