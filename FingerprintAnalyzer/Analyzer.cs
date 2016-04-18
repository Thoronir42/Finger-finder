using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerprintAnalyzer.ImageManipulation;
using FingerprintAnalyzer.Model;

namespace FingerprintAnalyzer
{
    /// <summary>
    /// Interface grouping fingerprint analyzation controls
    /// </summary>
    public class Analyzer
    {

        public const int 
            FINGERPRINT_ORIGINAL = 0,
            FINGERPRINT_EQUALIZATION = 1,
            FINGERPRINT_TRESHOLDING = 2,
            FINGERPRINT_SKELETONIZED = 3;

        public const int
            STAGE_ORIGINAL = 0,
            STAGE_EQUALIZED = 1,
            STAGE_TRESHOLDED = 2,
            STAGE_SKELETIZED = 3;


        public Fingerprint Fingerprint { get; private set; }

        public Image ImageOriginal { get; private set; }
        public Image ImageEqualization { get; private set; }
        public Image ImageTresholding { get; private set; }
        public Image ImageSkeleton { get; private set; }

        public int CurrentStage { get; private set; }

        private MinutiaeDetector MinutiaeDetector { get; } = new MinutiaeDetector();
        private FingerprintClassificator FingerprintClassificator { get; } = new FingerprintClassificator();
        private FingerprintXML<Fingerprint> XML { get; } = new FingerprintXML<Fingerprint>();


        public void createNewFromImage(Image original)
        {
            Fingerprint = new Fingerprint();
            ImageOriginal = original;
            CurrentStage = STAGE_ORIGINAL;
        }

        public Image transformEqualization()
        {
            CurrentStage = STAGE_EQUALIZED
            return ImageEqualization = (new ImageEqualizer()).transform(ImageOriginal);
        }

        public Image transformTresholding(int tresholdLevel)
        {
            CurrentStage = STAGE_SKELETIZED;
            return ImageTresholding = (new ImageTresholder { TresholdLevel = tresholdLevel }).transform(ImageOriginal);
        }

        public Image transformSkeletonize()
        {
            CurrentStage = STAGE_SKELETIZED;
            return ImageSkeleton = new ImageSkeletonizer().transform(ImageTresholding);
        }

        /// <summary>
        /// Returns image corresponding to requested stageNumber or original if stage number wasn't recognised
        /// </summary>
        /// <param name="stageNumber">Stage number specifying requested image</param>
        /// <returns>Corresponding image</returns>
        public Image getImage(int stageNumber)
        {
            switch (stageNumber)
            {
                default:
                case FINGERPRINT_ORIGINAL: return ImageOriginal;
                case FINGERPRINT_EQUALIZATION: return ImageEqualization;
                case FINGERPRINT_TRESHOLDING: return ImageTresholding;
                case FINGERPRINT_SKELETONIZED: return ImageSkeleton;
            }
        }


        /// <summary>
        /// Temporary method assigning testing data to fingerprint
        /// </summary>
        public void mockAnalyzeAndClassify()
        {
            Fingerprint.Minutiae = MinutiaeDetector.detectMinituae(ImageSkeleton);
            Fingerprint.Category = FingerprintClassificator.classificate(ImageSkeleton);
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
            this.XML.Save(Fingerprint, filename);
            return true;
        }
    }
}
