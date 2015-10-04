using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Helpers
{
    public static class DateUtils
    {
        public static void ValidateDateTimeBetween(DateTime target, DateTime actual, TimeSpan allowedDiff)
        {
            // both to UTC
            target = target.ToUniversalTime();
            actual = actual.ToUniversalTime();

            var move = allowedDiff.Ticks / 2;
            Assert.IsTrue(target.AddMilliseconds(-move) < actual, string.Format("Date outside limiter {0} <> {1}", target, actual));
            Assert.IsTrue(actual < target.AddMilliseconds(move), string.Format("Date outside limiter {0} <> {1}", target, actual));
        }
    }
}
