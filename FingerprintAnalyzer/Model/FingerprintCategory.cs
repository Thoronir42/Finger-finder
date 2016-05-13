using System.Xml.Serialization;

namespace FingerprintAnalyzer.Model
{
    /// <summary>
    /// Classifiable fingerprint categories
    /// </summary>
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
