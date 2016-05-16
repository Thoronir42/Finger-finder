using System;

namespace FingerprintAnalyzer.PreProcess.Sequences
{
    public class Stage
    {
        String label;
        private static Stage
            stageJustOpened = new Stage("Just opened"),
            stageChoosingSequence = new Stage("Choosing sequence"),
            stageFinal = new Stage("Final");

        public static Stage JustOpened { get { return stageJustOpened; } }
        public static Stage ChoosingSequence { get { return stageChoosingSequence; } }
        
        public static Stage Final { get { return stageFinal; } }

        public bool IsPreprocessStage { get { return this.GetType() != typeof(Stage); } }

        protected Stage(string label)
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

    public delegate void StageChangedEventHandler(object sender, StageChangedEventArgs e);

    public class StageChangedEventArgs : EventArgs
    {
        public Stage OldStage { get; set; }
        public Stage NewStage { get; set; }
    }
}
