using System.Drawing;
using FingerprintAnalyzer.Model;
using System.Collections.Generic;
using System;
using FingerprintAnalyzer.PreProcess.Sequences;

namespace FingerprintAnalyzer.Analyze
{
    /// <summary>
    /// Interface grouping fingerprint analyzation controls
    /// </summary>
    public partial class Analyzer : BaseModel
    {
        private FingerprintData fingerprintData;
        public FingerprintData FingerprintData { get { return fingerprintData; } private set { fingerprintData = value; NotifyPropertyChanged(); } }

        private void stageChanged(Stage oldValue, Stage newValue)
        {
            var args = new StageChangedEventArgs { OldStage = oldValue, NewStage = newValue };
            StageChanged?.Invoke(this, args);
        }

        private MinutiaeDetector MinutiaeDetector { get; } = new MinutiaeDetector();
        private FingerprintClassificator FingerprintClassificator { get; } = new FingerprintClassificator();

        

        

        /// <summary>
        /// Finds minutiae and classificates fingerprint
        /// </summary>
        public void analyzeFingerprint()
        {
            Image finalImage = Images[Stage.Final];
            FingerprintData.Minutiae.Clear();
            foreach(Minutia minutia in MinutiaeDetector.detectMinituae(finalImage))
            {
                FingerprintData.Minutiae.Add(minutia);
            }
            
            FingerprintData.Category = FingerprintClassificator.classificate(finalImage);
        }
    }

    public delegate void StageChangedEventHandler(Analyzer sender, StageChangedEventArgs e);
    public class StageChangedEventArgs : EventArgs
    {
        public Stage OldStage { get; set; }
        public Stage NewStage { get; set; }
    }
}
