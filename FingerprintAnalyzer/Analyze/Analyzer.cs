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
        public FingerprintData FingerprintData {
            get { return fingerprintData; }
            private set
            {
                fingerprintData = value;
                NotifyPropertyChanged();
            }
        }

        private MinutiaeDetector MinutiaeDetector { get; } = new MinutiaeDetector();
        private FingerprintClassificator FingerprintClassificator { get; } = new FingerprintClassificator();

        private bool canAnalyze = false;
        public bool CanAnalyze {
            get { return canAnalyze; }
            private set
            {
                canAnalyze = value;
                NotifyPropertyChanged();
            }
        }

        private Image fingerprintImage;
        public Image FingerprintImage {
            get { return fingerprintImage; }
            private set
            {
                fingerprintImage = value;
                NotifyPropertyChanged();
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

        public void SetFingerprint(Image image, FingerprintData data)
        {
            FingerprintImage = image;
            FingerprintData = data;
            canAnalyze = true;
        }

        public void SetFingerprint(Image image, bool clearFingerprintData = false)
        {
            FingerprintImage = image;
            if(clearFingerprintData || FingerprintData == null)
            {
                FingerprintData = new FingerprintData();
            }
        }
    }
}
