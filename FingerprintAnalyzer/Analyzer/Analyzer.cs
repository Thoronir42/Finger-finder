using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerprintAnalyzer.ImageManipulation;
using FingerprintAnalyzer.Model;
using System.Collections.ObjectModel;

namespace FingerprintAnalyzer.Analyze
{
    /// <summary>
    /// Interface grouping fingerprint analyzation controls
    /// </summary>
    public class Analyzer : BaseModel
    {
        private AnalyzerStages currentStage = AnalyzerStages.Original;

        public FingerprintData FingerprintData { get; private set; }

        public Image ImageOriginal { get; private set; }
        public Image ImageEqualization { get; private set; }
        public Image ImageTresholding { get; private set; }
        public Image ImageSkeleton { get; private set; }

        public AnalyzerStages CurrentStage {
            get { return currentStage; }
            set { currentStage = value; NotifyPropertyChanged(); NotifyPropertyChanged("CurrentImage"); } }

        public Image CurrentImage { get{ return this.getImageFor(CurrentStage); } }

        private MinutiaeDetector MinutiaeDetector { get; } = new MinutiaeDetector();
        private FingerprintClassificator FingerprintClassificator { get; } = new FingerprintClassificator();
        private FingerprintXML XML { get; } = new FingerprintXML();


        public void createNewFromImage(Image original)
        {
            FingerprintData = new FingerprintData();
            ImageOriginal = original;
            CurrentStage = AnalyzerStages.Original;
        }

        public Image transformEqualization()
        {
            CurrentStage = AnalyzerStages.Equalized;
            return ImageEqualization = (new ImageEqualizer()).transform(ImageOriginal);
        }

        public Image transformTresholding(int tresholdLevel)
        {
            CurrentStage = AnalyzerStages.Tresholded;
            return ImageTresholding = (new ImageTresholder { TresholdLevel = tresholdLevel }).transform(ImageOriginal);
        }

        public Image transformSkeletonize()
        {
            CurrentStage = AnalyzerStages.Skeletonized;
            return ImageSkeleton = new ImageSkeletonizer().transform(ImageTresholding);
        }

        /// <summary>
        /// Returns image corresponding to requested stageNumber or original if stage number wasn't recognised
        /// </summary>
        /// <param name="stage">Stage number specifying requested image</param>
        /// <returns>Corresponding image</returns>
        public Image getImageFor(AnalyzerStages stage)
        {
            switch (stage)
            {
                default:
                case AnalyzerStages.Original: return ImageOriginal;
                case AnalyzerStages.Equalized: return ImageEqualization;
                case AnalyzerStages.Tresholded: return ImageTresholding;
                case AnalyzerStages.Skeletonized: return ImageSkeleton;
            }
        }


        /// <summary>
        /// Temporary method assigning testing data to fingerprint
        /// </summary>
        public void mockAnalyzeAndClassify()
        {
            FingerprintData.Minutiae = new ObservableCollection<Minutia>(MinutiaeDetector.detectMinituae(ImageSkeleton));
            FingerprintData.Category = FingerprintClassificator.classificate(ImageSkeleton);
        }

        /// <summary>
        /// Loads fingerprint datafrom file
        /// TODO: specify which image (if any) will be saved alongside fingerprint data
        /// </summary>
        /// <param name="filename">Location of file containing fingerprint data</param>
        /// <returns>Succesfullness of operation</returns>
        public bool loadFromFile(string filename)
        {
            this.XML.Load(filename);
            return true;
        }

        /// <summary>
        /// Saves fingerprint data to file
        /// TODO: specify which image (if any) will be saved alongside fingerprint data
        /// </summary>
        /// <param name="filename">Desired destination for fingerprint data file</param>
        /// <returns>Succesfullness of operation</returns>
        public bool saveToFile(string filename)
        {
            this.XML.Save(FingerprintData, filename);
            return true;
        }
    }
}
