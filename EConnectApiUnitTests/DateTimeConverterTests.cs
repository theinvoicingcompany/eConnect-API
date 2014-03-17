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
            // 2014-02-01 20:25
            const long javaTimeStamp = 1391282758111;

            // Convert to .net DateTime object
            var dt = DateTimeConverter.ToDateTime(javaTimeStamp);
            Assert.AreEqual(new DateTime(2014, 2, 1, 20, 25, 58, 111), dt);

            // Convert back to java timestamp
            var stamp = DateTimeConverter.ToJavaTimestamp(dt);
            Assert.AreEqual(javaTimeStamp, stamp);
        }

        [TestMethod]
        public void DateTimeConverterJavaToDateTimeAndBackTest()
        {
            // Get stamp
            var stamp = DateTime.Now.ToJavaTimestamp();
            // Convert back to datetime
            var dt = DateTimeConverter.ToDateTime(stamp);
            // And again back to stamp
            var stamp2 = DateTimeConverter.ToJavaTimestamp(dt);
            
            Assert.AreEqual(stamp, stamp2);
        }

    }
}
