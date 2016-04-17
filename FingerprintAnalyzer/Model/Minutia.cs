using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace FingerprintAnalyzer.Model
{
    public class Minutia
    {
        [XmlElement("Position")]
        public PointF Position { get; set; } = new PointF();
        [XmlElement("Type")]
        public MinutiaType Type { get; set; } = MinutiaType.Unspecified;
    }

    public enum MinutiaType
    {
        [XmlEnum("N/A")]
        Unspecified,
        [XmlEnum("RE")]
        RidgeEnding,
        [XmlEnum("RB")]
        RidgeBifurcation,
        [XmlEnum("SR")]
        ShortRidge,
        [XmlEnum("I")]
        Island,
        [XmlEnum("RC")]
        RidgeEnclosure,
        [XmlEnum("S")]
        Spur,
        [XmlEnum("COB")]
        CrossoverOrBridge,
        [XmlEnum("D")]
        Delta,
        [XmlEnum("C")]
        Core
    }
}
