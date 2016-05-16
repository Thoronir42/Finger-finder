using System.Drawing;

using System.Xml.Serialization;

namespace FingerprintAnalyzer.Model
{
    /// <summary>
    /// Minutia container
    /// </summary>
    public class Minutia : BaseModel
    {
        private MinutiaType type = MinutiaType.Unspecified;
        [XmlAttribute("Type")]
        public MinutiaType Type {
            get { return type; }
            set
            {
                type = value;
                NotifyPropertyChanged();
            }
        }

        private PointF position = new PointF();
        
        [XmlElement("X")]
        public float X {
            get { return position.X; }
            set
            {
                position.X = value;
                NotifyPropertyChanged();
            }
        }

        [XmlElement("Y")]
        public float Y
        {
            get { return position.Y; }
            set
            {
                position.Y = value;
                NotifyPropertyChanged();
            }
        }


        public override string ToString()
        {
            return $"{Type} at [{X}, {Y}]";
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
