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
        [XmlIgnore]
        public MinutiaType Type {
            get { return type; }
            set
            {
                type = value;
                NotifyPropertyChanged();
            }
        }

        [XmlAttribute("Type")]
        public string _MinutiaTypeString {
            get { return Type.Serialisation; }
            set { Type = MinutiaType.ParseSerialiseString(value); }
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
}
