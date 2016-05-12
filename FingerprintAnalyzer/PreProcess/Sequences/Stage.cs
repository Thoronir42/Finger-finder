using System;

namespace FingerprintAnalyzer.PreProcess.Sequences
{
    public class Stage
    {
        String label;
        private static Stage
            stageOriginal = new Stage("Original"),
            stageFinal = new Stage("Final");

        public static Stage Original
        {
            get { return stageOriginal; }
        }
        public static Stage Final
        {
            get { return stageFinal; }
        }

        public Stage(string label)
        {
            this.label = label;
        }

        public override string ToString()
        {
            return $"Stage {label}";
        }


        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return this.label.Equals((obj as Stage).label);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * label.GetHashCode();
        }

    }
}
