using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FingerprintAnalyzer.Model
{
    public enum FingerprintCategory
    {
        [XmlEnum("N/A")]
        Undefined,

        [XmlEnum("AP")]
        ArchPlain,
        [XmlEnum("AT")]
        ArchTented,
        [XmlEnum("LR")]
        LoopRadial,
        [XmlEnum("LU")]
        LoopUlnar,
        [XmlEnum("WP")]
        WhorlPlain,
        [XmlEnum("WCP")]
        WhorlCentralPocket,
        [XmlEnum("WDL")]
        WhorlDoubleLoop,
        [XmlEnum("WA")]
        WhorlAccidental
    }
}
