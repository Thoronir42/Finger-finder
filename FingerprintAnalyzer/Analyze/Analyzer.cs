using System.Drawing;
using FingerprintAnalyzer.ImageManipulation;
using FingerprintAnalyzer.Model;
using System.Collections.ObjectModel;

namespace FingerprintAnalyzer.Analyze
{
    /// <summary>
    /// Interface grouping fingerprint analyzation controls
    /// </summary>
    public partial class Analyzer : BaseModel
    {
        private Stages currentStage = Stages.Standby;
        private FingerprintData fingerprintData;

        public FingerprintData FingerprintData { get { return fingerprintData; } private set { fingerprintData = value; NotifyPropertyChanged(); } }

        public Image ImageOriginal { get; private set; }
        public Image ImageEqualization { get; private set; }
        public Image ImageTresholding { get; private set; }
        public Image ImageSkeleton { get; private set; }

        public Stages CurrentStage {
            get { return currentStage; }
            set
            {
                var oldStage = currentStage;
                currentStage = value;
                NotifyPropertyChanged();
                stageChanged(oldStage, value);
                NotifyPropertyChanged("CurrentImage");
            } }

        public Image CurrentImage { get{ return this.getImageFor(CurrentStage); } }

        private MinutiaeDetector MinutiaeDetector { get; } = new MinutiaeDetector();
        private FingerprintClassificator FingerprintClassificator { get; } = new FingerprintClassificator();
        

        public Image transformEqualization()
        {
            CurrentStage = Stages.Equalized;
            return ImageEqualization = (new ImageEqualizer()).transform(ImageOriginal);
        }

        public Image transformTresholding(int tresholdLevel, bool preview = false)
        {
            if (!preview) {
                CurrentStage = Stages.Tresholded;
            }
            return ImageTresholding = (new ImageTresholder { TresholdLevel = tresholdLevel }).transform(ImageOriginal);
        }

        public Image transformSkeletonize()
        {
            CurrentStage = Stages.Skeletonized;
            return ImageSkeleton = new ImageSkeletonizer().transform(ImageTresholding);
        }

        /// <summary>
        /// Returns image corresponding to requested stageNumber or original if stage number wasn't recognised
        /// </summary>
        /// <param name="stage">Stage number specifying requested image</param>
        /// <returns>Corresponding image</returns>
        public Image getImageFor(Stages stage)
        {
            switch (stage)
            {
                default:
                case Stages.Original: return ImageOriginal;
                case Stages.Equalized: return ImageEqualization;
                case Stages.Tresholded: return ImageTresholding;
                case Stages.Skeletonized: return ImageSkeleton;
            }
        }

        /// <summary>
        /// Finds minutiae and classificates fingerprint
        /// </summary>
        public void analyzeFingerprint()
        {
            FingerprintData.Minutiae.Clear();
            foreach(Minutia minutia in MinutiaeDetector.detectMinituae(ImageSkeleton))
            {
                FingerprintData.Minutiae.Add(minutia);
            }
            
            FingerprintData.Category = FingerprintClassificator.classificate(ImageSkeleton);
        }
    }
}
