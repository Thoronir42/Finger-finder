using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.ImageManipulation
{
    public abstract class AImageManipulator
    {
        public const float LUMINANCY_COEFICIENT_RED = 0.299f;
        public const float LUMINANCY_COEFICIENT_GREEN = 0.587f;
        public const float LUMINANCY_COEFICIENT_BLUE = 0.114f;

        public abstract Image transform(Image original);

        protected int colorToLuminance(Color c)
        {
            return (int)Math.Round(LUMINANCY_COEFICIENT_RED * c.R + LUMINANCY_COEFICIENT_GREEN * c.G + LUMINANCY_COEFICIENT_BLUE * c.B);
        }
    }
}
