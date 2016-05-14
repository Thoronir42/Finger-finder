using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.PreProcess.ImageManipulation.ImageTools
{
    class ImageMatrixSign : ImageMatrix
    {
        public ImageMatrixSign(int[,] M) : base(M) { }
        public ImageMatrixSign(Bitmap image) : base(image) { }

        protected override Color getColor(int c)
        {
            c = c < 0 ? 0 : 255;
            return base.getColor(c);
        }
    }
}
