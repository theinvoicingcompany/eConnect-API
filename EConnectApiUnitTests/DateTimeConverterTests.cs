using System;
using EConnectApi.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiUnitTests
{
    [TestClass]
    public class DateTimeConverterTests
    {
        [TestMethod]
        public void DateTimeConverterTest()
        {
            // GMT: Sat, 01 Feb 2014 19:25:58 GMT
            // NL summer time zone: 1-2-2014 20:25:58 GMT+1:00
            const long javaTimeStamp = 1391282758111;

            // Convert to .net DateTime object
            var dt = DateTimeConverter.ToDateTime(javaTimeStamp);
            Assert.AreEqual(new DateTime(2014, 2, 1, 19, 25, 58, 111, DateTimeKind.Utc), dt);

            // Convert back to java timestamp
            var stamp = DateTimeConverter.ToJavaTimestamp(dt);
            Assert.AreEqual(javaTimeStamp, stamp);
        }

        [TestMethod]
        public void DateTimeConverterJavaToDateTimeAndBackTest()
        {
            // Get stamp
            var stamp = new DateTime(2014, 9, 18, 12, 50, 15, DateTimeKind.Utc).ToJavaTimestamp();
            // Convert back to datetime
            var dt = DateTimeConverter.ToDateTime(stamp);
            // And again back to stamp
            var stamp2 = DateTimeConverter.ToJavaTimestamp(dt);

            Assert.AreEqual(stamp, stamp2);
        }

        [TestMethod]
        public void DateTimeConverterJavaToDateTimeLocalAndBackTest()
        {
            // Get stamp
            var stamp = new DateTime(2014, 9, 18, 12, 50, 15, DateTimeKind.Local).ToJavaTimestamp();
            // Convert back to datetime
            var dt = DateTimeConverter.ToDateTime(stamp);
            // And again back to stamp
            var stamp2 = DateTimeConverter.ToJavaTimestamp(dt);

            Assert.AreEqual(stamp, stamp2);
        }        
    }
}
