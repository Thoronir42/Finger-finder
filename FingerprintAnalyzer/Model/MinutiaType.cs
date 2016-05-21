using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.Model
{


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
        public static MinutiaType RidgeEnding { get { return ridgeEnding; } }
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
            foreach (var type in types)
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
