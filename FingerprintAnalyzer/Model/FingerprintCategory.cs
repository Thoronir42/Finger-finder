using System.Xml.Serialization;

namespace FingerprintAnalyzer.Model
{
    /// <summary>
    /// Classifiable fingerprint categories
    /// </summary>
    public sealed class FingerprintCategory
    {
        private static FingerprintCategory
            undefined = new FingerprintCategory("Nerozpoznaná", "N/A"),
            archPlain = new FingerprintCategory("Oblouk", "AP"),
            archTented = new FingerprintCategory("Oblouk vypjatý", "AT"),
            loopRadial = new FingerprintCategory("Smyčka paprsková", "LR"),
            loopUnar = new FingerprintCategory("Smyčka jednoduchá", "LU"),
            whorlPlain = new FingerprintCategory("Závitnice jednoduchá", "WP"),
            whorlCentralPocket = new FingerprintCategory("Závitnice s kapsou uprostřed", "WCP"),
            whorlDoubleLoop = new FingerprintCategory("Závitnice dvojitá", "WDL"),
            whorlAccidental = new FingerprintCategory("Závitnice omylná", "WA");

        public static FingerprintCategory Undefined{ get { return undefined; } }
        public static FingerprintCategory ArchPlain { get { return archPlain; } }
        public static FingerprintCategory ArchTented { get { return archTented; } }
        public static FingerprintCategory LoopRadial { get { return loopRadial; } }
        public static FingerprintCategory LoopUnar { get { return loopUnar; } }
        public static FingerprintCategory WhorlPlain { get { return whorlPlain; } }
        public static FingerprintCategory WhorlCentralPocket { get { return whorlCentralPocket; } }
        public static FingerprintCategory WhorlDoubleLoop { get { return whorlDoubleLoop; } }
        public static FingerprintCategory WhorlAccidental { get { return whorlAccidental; } }

        public static FingerprintCategory[] GetAllValues()
            {
                return new FingerprintCategory[]{
                Undefined,
                ArchPlain,
                ArchTented,
                LoopRadial,
                LoopUnar,
                WhorlPlain,
                WhorlCentralPocket,
                WhorlDoubleLoop,
                WhorlAccidental,

                };
            }

            public static FingerprintCategory ParseSerialiseString(string serialsed)
            {
                FingerprintCategory[] types = GetAllValues();
                foreach (var type in types)
                {
                    if (type.Serialisation.Equals(serialsed))
                    {
                        return type;
                    }
                }
                System.Console.Error.WriteLine($"Fingerprint category parse failed for {serialsed}");
                return undefined;
            }

        private string label;
        private string serialisation;

        public string Label { get { return label; } }
        public string Serialisation { get { return serialisation; } }

        public FingerprintCategory(string label, string serialisation)
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
