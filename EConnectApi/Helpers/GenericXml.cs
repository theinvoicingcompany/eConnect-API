using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Xml;
using System.Xml.Serialization;



namespace EConnectApi.Helpers
{
    internal static class GenericXml
    {
        public static T Deserialize<T>(string input) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
#if DEBUG
            AttachDebugger(ref serializer);
#endif
            using (var sr = new StringReader(input))
            {
                var obj = (T)serializer.Deserialize(sr);
#if DEBUG
                LogPropertiesWithNullValues(obj);
#endif
                return obj;
            }
        }

        public static T DeserializeSoap<T>(string input) where T : class
        {
            // SOAP Format defined in .NET using: System.Runtime.Serialization.Formatters.Soap.dll
            var formatter = new SoapFormatter();
            // convert string to stream
            byte[] byteArray = Encoding.UTF8.GetBytes(input);
            var stream = new MemoryStream(byteArray);
            //
            return (T)formatter.Deserialize(stream);
        }

        public static string Serialize(object input)
        {
            //var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(input.GetType());
#if DEBUG
            AttachDebugger(ref serializer);
#endif
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, input/*, emptyNamepsaces*/);
                return stream.ToString();
            }
        }

        public static string SerializeSoap(object input)
        {
            var myMapping = (new SoapReflectionImporter().ImportTypeMapping(input.GetType()));
            var serializer = new XmlSerializer(myMapping);
#if DEBUG
            AttachDebugger(ref serializer);
#endif
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, input/*, emptyNamepsaces*/);
                return stream.ToString();
            }
        }


#if DEBUG

        private static void XmlSerializer_OnUnknownElement(object sender, XmlElementEventArgs e)
        {
            Debug.WriteLine(string.Format("Unexpected element: {0} as line {1}, column {2}", e.Element.Name, e.LineNumber, e.LinePosition));
        }

        private static void XmlSerializer_OnUnknownNode(object sender, XmlNodeEventArgs e)
        {
            Debug.WriteLine(string.Format("Unexpected node: {0} as line {1}, column {2}", e.LocalName, e.LineNumber, e.LinePosition));
        }

        private static void XmlSerializer_OnUnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            Debug.WriteLine(string.Format("Unexpected attribute: {0} as line {1}, column {2}", e.Attr.Name, e.LineNumber, e.LinePosition));
        }

        private static void XmlSerializer_OnUnreferencedObject(object sender, UnreferencedObjectEventArgs e)
        {
            Debug.WriteLine(string.Format("UnreferencedObject: {0}, UnreferencedId: {1}", e.UnreferencedObject, e.UnreferencedId));
        }

        private static void AttachDebugger(ref XmlSerializer ser)
        {
            ser.UnknownElement += XmlSerializer_OnUnknownElement;
            //ser.UnknownNode += XmlSerializer_OnUnknownNode;
            ser.UnknownAttribute += XmlSerializer_OnUnknownAttribute;
            ser.UnreferencedObject += XmlSerializer_OnUnreferencedObject;
        }

        public static void LogPropertiesWithNullValues(object input) 
        {
            var type = input.GetType();
            var props = type.GetProperties().Where(p => p.PropertyType.FullName.StartsWith("EConnectApi."));
            foreach (var prop in props)
            {
                if (prop.PropertyType.IsArray)
                {
                    var array = (object[]) prop.GetValue(input, null);
                    foreach (var o in array)
                    {
                        if(o!=null)
                            LogPropertiesWithNullValues(o);
                    }
                 
                    continue;
                }
                var val = prop.GetValue(input, null);
                if (val != null)
                    LogPropertiesWithNullValues(val);
            }
          

            var empty = type.GetProperties().Where(p => p.GetValue(input, null) == null).Select(p => p.Name).ToArray();
            if (empty.Length > 0)
                Debug.WriteLine(string.Format("Null properties for {0}: {1}", type, string.Join(", ", empty)), "Warning");
        }

#endif
    }
}
