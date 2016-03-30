using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerFinder
{
    public partial class FingerprintAnalyzer
    {
        private Image fingerprintOriginal;
        private Image fingerpintSkeleton;

        Image FingerprintOriginal
        {
            get { return fingerprintOriginal; }
            set
            {
                fingerprintOriginal = value;
                fingerpintSkeleton = createFingerprintSkeleton(value);

            }
        }
        Image FingerprintSkeleton { get { return this.fingerpintSkeleton; } }

        private Image createFingerprintSkeleton(Image original)
        {
            return original;
        }
    }
}
