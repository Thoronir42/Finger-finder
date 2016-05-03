using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.Analyze
{
    public delegate void StageChangedEventHandler (Analyzer sender, StageChangedEventArgs e);
    
    public partial class Analyzer
    {
        public event StageChangedEventHandler StageChanged;

        public static Stages FirstStage { get { return Stages.Original; } }
        public static Stages LastStage { get { return Stages.Finalised; } }

        public enum Stages
        {
            Standby = -1,
            Original = 0,
            Equalized = 1,
            Tresholded = 2,
            Skeletonized = 3,
            Finalised = 4,
        }

        private void stageChanged(Stages oldValue, Stages newValue)
        {
            var args = new StageChangedEventArgs { OldStage = oldValue, NewStage = newValue };
            StageChanged?.Invoke(this, args);
        }
    }

    public class StageChangedEventArgs : EventArgs
    {
        public Analyzer.Stages OldStage { get; set; }
        public Analyzer.Stages NewStage { get; set; }
    }
    
}
