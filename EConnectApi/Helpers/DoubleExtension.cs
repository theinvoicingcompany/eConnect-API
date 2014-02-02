using System;

namespace EConnectApi.Helpers
{
    internal static class DoubleExtension
    {
        public static DateTime ToDateTime(this double stamp)
        {
            return DateTimeConverter.ToDateTime(stamp);
        }
    }
}