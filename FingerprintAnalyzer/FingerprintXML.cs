using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace FingerprintAnalyzer
{
    public class FingerprintXML<Type>
    {
        public void Save(Type typeInstance, string fileName)
        {
            var xs = new XmlSerializer(typeof(Type));

            using (var writer = XmlWriter.Create(fileName, new XmlWriterSettings() { Indent = true }))
            {
                xs.Serialize(writer, typeInstance);
            }
        }

        public Type Load(string fileName)
        {
            Type result;

            var xs = new XmlSerializer(typeof(Type));

            using (var reader = XmlReader.Create(fileName))
            {
                result = (Type)xs.Deserialize(reader);
            }

            return result;
        }
    }
}
