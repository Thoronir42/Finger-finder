using System.Drawing;
using FingerprintAnalyzer.Model;
using System;

namespace FingerprintAnalyzer.Analyze
{
    /// <summary>
    /// Interface grouping fingerprint analyzation controls
    /// </summary>
    public partial class Analyzer : BaseModel
    {
        private FingerprintData fingerprintData;
        public FingerprintData FingerprintData { get { return fingerprintData; } private set { fingerprintData = value; NotifyPropertyChanged(); } }

        private MinutiaeDetector MinutiaeDetector { get; } = new MinutiaeDetector();
        private FingerprintClassificator FingerprintClassificator { get; } = new FingerprintClassificator();

        public bool CanAnalyze { get { return FingerprintImage != null; } }

        private Image fingerprintImage;
        public Image FingerprintImage {
            get { return fingerprintImage; }
            set
            {
                if(fingerprintImage == null)
                {
                    FingerprintData = new FingerprintData();
                }
                fingerprintImage = value;
                NotifyPropertyChanged("CanAnalyze");
            }
        }

        

        /// <summary>
        /// Finds minutiae and classificates fingerprint
        /// </summary>
        public void analyzeFingerprint()
        {
            FingerprintData.Minutiae.Clear();
            foreach(Minutia minutia in MinutiaeDetector.detectMinituae(FingerprintImage))
            {
                FingerprintData.Minutiae.Add(minutia);
            }
            
            FingerprintData.Category = FingerprintClassificator.classificate(FingerprintImage);
        }
    }
}
