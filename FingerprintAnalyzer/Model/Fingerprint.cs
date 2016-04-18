using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace FingerprintAnalyzer.Model
{
    /// <summary>
    /// Fingerprint data container
    /// </summary>
    public class Fingerprint
    {
        [XmlElement("SavedOn")]
        public DateTime DateSaved { get; set; } = DateTime.Now;

        [XmlElement("Name")]
        public string Name { get; set; } = "John Doe";

        [XmlElement("Minutiae")]
        public List<Minutia> Minutiae { get; set; } = new List<Minutia>();

        [XmlElement("Category")]
        public FingerprintCategory Category { get; set; } = FingerprintCategory.Undefined;

    }
}
