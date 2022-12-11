using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Skyware.Identisio.Utils
{
    public class XmlUtils
    {
        public static string GetXML(object Obj, string prefix = null, string nspace = null)
        {
            if (Obj is null) return null;
            XmlSerializerNamespaces ns = null;
            if (!string.IsNullOrWhiteSpace(prefix) && !string.IsNullOrWhiteSpace(nspace))
            {
                ns = new XmlSerializerNamespaces();
                ns.Add(prefix, nspace);
            }
            var ser = new XmlSerializer(Obj.GetType());
            using (var ms = new MemoryStream())
            {
                ser.Serialize(ms, Obj, ns);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public static void WriteObject(object Obj, Stream Stream)
        {
            if (Stream is null) throw new ArgumentNullException(nameof(Stream), $"{nameof(Stream)} can't be null.");
            if (Obj is null) throw new ArgumentNullException(nameof(Obj), $"{nameof(Obj)} can't be null.");
            var buf = Encoding.UTF8.GetBytes(GetXML(Obj));
            Stream.Write(buf, 0, buf.Length);
        }

        public static void WriteObject(object Obj, string filepath)
        {
            if (string.IsNullOrWhiteSpace(filepath)) throw new ArgumentNullException(nameof(filepath), $"{nameof(filepath)} can't be null or empty.");
            if (Obj is null) throw new ArgumentNullException(nameof(Obj), $"{nameof(Obj)} can't be null.");
            Directory.CreateDirectory(Path.GetDirectoryName(filepath));
            FileMode mode = FileMode.OpenOrCreate;
            if (File.Exists(filepath)) mode = FileMode.Truncate;
            var ser = new XmlSerializer(Obj.GetType());
            using (var ws = new FileStream(filepath, mode))
            {
                ser.Serialize(ws, Obj);
                ws.Flush();
            }
        }

        public static T GetObject<T>(Stream Stream)
        {
            if (Stream is null) return default;
            var ser = new XmlSerializer(typeof(T));
            return (T)ser.Deserialize(Stream);
        }

        public static T GetObject<T>(string XML)
        {
            if (string.IsNullOrWhiteSpace(XML)) return default;
            var ser = new XmlSerializer(typeof(T));
            using (var sr = new MemoryStream(Encoding.UTF8.GetBytes(XML)))
            {
                return (T)ser.Deserialize(sr);
            }
        }


    }
}
