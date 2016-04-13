using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerprintAnalyzer.Manipulators;

namespace FingerprintAnalyzer
{
    public partial class Analyzer
    {
        const int FINGERPRINT_ORIGINAL = 0;
        const int FINGERPRINT_EQUALIZATION = 1;
        const int FINGERPRINT_TRESHOLDING = 2;
        const int FINGERPRINT_SKELETONIZED = 3;

        public Image FingerprintOriginal { get; set; }
        public Image FingerprintEqualization { get; private set; }
        public Image FingerprintTresholding { get; private set; }
        public Image FingerprintSkeleton { get; private set; }

        public void originalChanged()
        {
            {
                FingerprintEqualization = doHistogramEqualization(FingerprintOriginal);
                FingerprintTresholding = doTresholding(FingerprintEqualization, 128);
                FingerprintSkeleton = createFingerprintSkeleton(FingerprintTresholding);

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
                case FINGERPRINT_ORIGINAL: return FingerprintOriginal;
                case FINGERPRINT_EQUALIZATION: return FingerprintEqualization;
                case FINGERPRINT_TRESHOLDING: return FingerprintTresholding;
                case FINGERPRINT_SKELETONIZED: return FingerprintSkeleton;
            }
        }
    }
}
