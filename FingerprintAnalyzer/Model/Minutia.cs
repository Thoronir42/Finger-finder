using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace FingerprintAnalyzer.Model
{
    /// <summary>
    /// Minutia container
    /// </summary>
    public class Minutia
    {
        [XmlElement("Position")]
        public PointF Position { get; set; } = new PointF();
        [XmlElement("Type")]
        public MinutiaType Type { get; set; } = MinutiaType.Unspecified;

        public override string ToString()
        {
            return $"{Type} at [{Position.X}, {Position.Y}]";
        }
    }

    /// <summary>
    /// Possible Minutia types
    /// </summary>
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
