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
        private string MinutiaTypeString {
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

    /// <summary>
    /// Possible Minutia types
    /// </summary>
    public sealed class MinutiaType
    {
        private static MinutiaType
            unspecified = new MinutiaType("Nespecifikováno", "N/A"),
            ridgeEnding = new MinutiaType("Zakončení hřbetu", "RE"),
            ridgeBifurcation = new MinutiaType("Bifurkace hřbetu", "RB"),
            ridgeEnclosure = new MinutiaType("Uzavření hřbetu", "RE"),
            shortRidge = new MinutiaType("Krátký hřbet", "SR"),
            island = new MinutiaType("Ostrůvek", "I"),
            spur = new MinutiaType("Výběžek", "S"),
            crossoverOrBridge = new MinutiaType("Překryv nebo most", "COB"),
            delta = new MinutiaType("Delta", "D"),
            core = new MinutiaType("Jádro", "C");

        public static MinutiaType Unspecified { get { return unspecified; } }
        public static MinutiaType RidgeEnding { get {return ridgeEnding; } }
        public static MinutiaType RidgeBifurcation { get { return ridgeBifurcation; } }
        public static MinutiaType RidgeEnclosure { get { return ridgeEnclosure; } }
        public static MinutiaType ShortRidge { get { return shortRidge; } }
        public static MinutiaType Island { get { return island; } }
        public static MinutiaType Spur { get { return spur; } }
        public static MinutiaType CrossoverOrBridge { get { return crossoverOrBridge; } }
        public static MinutiaType Delta { get { return delta; } }
        public static MinutiaType Core { get { return core; } }

        public static MinutiaType[] GetAllValues()
        {
            return new MinutiaType[]{
                Unspecified,
                RidgeEnding,
                RidgeBifurcation,
                RidgeEnclosure,
                ShortRidge,
                Island,
                Spur,
                CrossoverOrBridge,
                Delta,

            };
        }

        public static MinutiaType ParseSerialiseString(string serialsed)
        {
            MinutiaType[] types = GetAllValues();
            foreach(var type in types)
            {
                if (type.Serialisation.Equals(serialsed))
                {
                    return type;
                }
            }
            System.Console.Error.WriteLine($"Minutia type parse failed for {serialsed}");
            return Unspecified;
        }

        private string label;
        private string serialisation;

        public string Label { get { return label; } }
        public string Serialisation { get { return serialisation; } }

        private MinutiaType(string label, string serialisation)
        {
            this.label = label;
            this.serialisation = serialisation;
        }

        public override string ToString()
        {
            return label;
        }
    }
}
