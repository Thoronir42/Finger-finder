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

        public Image doSkeletonize()
        {
            return ImageSkeleton = new ImageSkeletonizer().transform(ImageTresholding);
        }

        /// <summary>
        /// Provede ekvalizaci histogramu, slouží k vyrovnání jasově nerovnoměrného obrazu otisku prstu
        /// </summary>
        /// <param name="original">Původní snímek</param>
        /// <returns></returns>
        public Image doHistogramEqualization()
        {
            return ImageEqualization = (new ImageEqualizer()).transform(ImageOriginal);
        }

        public Image doTresholding(int tresholdLevel)
        {

            return ImageTresholding = (new ImageTresholder { TresholdLevel = tresholdLevel }).transform(ImageOriginal);
        }


        public Image getImage(int imageIndex)
        {
            switch (imageIndex)
            {
                default:
                case FINGERPRINT_ORIGINAL: return ImageOriginal;
                case FINGERPRINT_EQUALIZATION: return ImageEqualization;
                case FINGERPRINT_TRESHOLDING: return ImageTresholding;
                case FINGERPRINT_SKELETONIZED: return ImageSkeleton;
            }
        }

        public void mockAnalyzeAndClassify()
        {
            Fingerprint.Minutiae = MinutiaeDetector.detectMinituae(ImageSkeleton);
            Fingerprint.Category = FingerprintClassificator.classificate(ImageSkeleton);
        }

        public bool loadFromFile(string filename)
        {
            this.XML.Load(filename);
            return true;
        }

        public bool saveToFile(string filename)
        {
            this.XML.Save(Fingerprint, filename);
            return true;
        }
    }
}
