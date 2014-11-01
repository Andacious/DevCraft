using System.IO;
using System.Xml.Serialization;

namespace DevCraft.Utility.Extensions
{
    public static class XmlExtensions
    {
        public static string ToXmlString<T>(this T obj)
        {
            string xmlResult;

            using (StringWriter writer = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());

                serializer.Serialize(writer, obj);

                xmlResult = writer.ToString();
            }

            return xmlResult;
        }

        public static T ToGenericObject<T>(this string xmlString)
        {
            T objectResult;

            using (StringReader reader = new StringReader(xmlString))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                objectResult = (T)serializer.Deserialize(reader);
            }

            return objectResult;
        }

        public static object ToObject(this string xmlString)
        {
            object obj = new object();

            using (StringReader reader = new StringReader(xmlString))
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());

                obj = serializer.Deserialize(reader);
            }

            return obj;
        }
    }
}