using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerFinder
{
    partial class FprintAnalyzer
    {
        private Image fingerprintOriginal;
        private Image fingerpintSkeleton;
        Image OriginalFingerprint
        {
            get { return fingerprintOriginal; }
            set
            {
                fingerprintOriginal = value;
                fingerpintSkeleton = createFingerprintSkeleton(value);

            }
        }

        private Image createFingerprintSkeleton(Image original)
        {
            return original;
        }
    }
}
