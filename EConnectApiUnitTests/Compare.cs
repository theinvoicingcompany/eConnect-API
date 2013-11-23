using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EConnectApi.Helpers;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiUnitTests
{
    public static class Compare
    {
        public static void IsObjectSameAsXml<T>(object obj, string xml) where T : class
        {
            var control = GenericXml.Deserialize<T>(xml);
            var xml2 = GenericXml.Serialize(obj);
            var test = GenericXml.Deserialize<T>(xml2);

            Assert.IsTrue(new CompareObjects().Compare(control, test), "Xml: {0} Object xml: {1}, Obj1: {2} Obj2: {3}", xml + Environment.NewLine, xml2 + Environment.NewLine, control + Environment.NewLine, obj + Environment.NewLine);
        }
    }
}
