using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TemporarySecretary
{
    class Configuration<T>
    {
        public static T Deserialize(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (Stream reader = new FileStream(file, FileMode.Open))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public static void Serialize(string file, T item)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamWriter writer = new StreamWriter(file, append: false))
            {
                serializer.Serialize(writer, item);
            }

        }
    }
}
