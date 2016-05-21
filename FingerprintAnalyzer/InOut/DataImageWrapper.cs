using FingerprintAnalyzer.Model;
using System.Xml.Serialization;

namespace FingerprintAnalyzer.InOut
{
    public class DataImageWrapper<Type>
    {
        [XmlElement("Version")]
        public VersionXml Version { get; set; }

        [XmlElement("Image")]
        public string ImageFilename { get; set; }

        [XmlElement("Item")]
        public Type Item { get; set; }
    
    }

    public class FingerprintWrapper : DataImageWrapper<FingerprintData> { }
}
