using System;

namespace EConnectApi.Helpers
{
    internal static class DoubleExtension
    {
        public static DateTime ToDateTime(this long stamp)
        {
            return DateTimeConverter.ToDateTime(stamp);
        }
    }
}