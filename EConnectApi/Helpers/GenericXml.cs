using System.IO;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;

namespace EConnectApi.Helpers
{ 
    internal static class GenericXml
    {
        public static T Deserialize<T>(string input) where T : class
        {
            var ser = new XmlSerializer(typeof(T));

            using (var sr = new StringReader(input))
                return (T)ser.Deserialize(sr);
        }

        public static string Serialize(object input)
        {
            //var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(input.GetType());
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


    }
}
