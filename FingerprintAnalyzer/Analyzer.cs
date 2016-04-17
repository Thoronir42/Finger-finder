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
    public partial class Analyzer
    {
        const int FINGERPRINT_ORIGINAL = 0;
        const int FINGERPRINT_EQUALIZATION = 1;
        const int FINGERPRINT_TRESHOLDING = 2;
        const int FINGERPRINT_SKELETONIZED = 3;


        public Fingerprint Fingerprint { get; private set; }

        public Image ImageOriginal { get; private set; }
        public Image ImageEqualization { get; private set; }
        public Image ImageTresholding { get; private set; }
        public Image ImageSkeleton { get; private set; }

        public void createNewFromImage(Image original)
        {
            Fingerprint = new Fingerprint();
            {
                ImageOriginal = original;
                ImageEqualization = doHistogramEqualization(ImageOriginal);
                ImageTresholding = doTresholding(ImageEqualization, 128);
                ImageSkeleton = createFingerprintSkeleton(ImageTresholding);

            }
        }

        public Image createFingerprintSkeleton(Image original)
        {
            return new ImageSkeletonizer().transform(original);
        }

        /// <summary>
        /// Provede ekvalizaci histogramu, slouží k vyrovnání jasově nerovnoměrného obrazu otisku prstu
        /// </summary>
        /// <param name="original">Původní snímek</param>
        /// <returns></returns>
        private Image doHistogramEqualization(Image original)
        {
            return (new ImageEqualizer()).transform(original);
        }

        public Image doTresholding(Image original, int tresholdLevel)
        {
            return (new ImageTresholder { TresholdLevel = tresholdLevel }).transform(original);
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
    }
}
