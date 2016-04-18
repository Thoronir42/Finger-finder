using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.ImageManipulation
{
    /// <summary>
    /// Transforms image into Black-White representation using customisable treshold level
    /// </summary>
    class ImageTresholder : AImageManipulator
    {
        public int TresholdLevel { get; set; } = 128;

        public override Image transform(Image original)
        {
            Bitmap origBitmap = new Bitmap(original);
            Bitmap result = new Bitmap(original.Width, original.Height);
            int gray;

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    gray = (colorToLuminance(origBitmap.GetPixel(x, y)) < TresholdLevel) ? 0 : 255;

                    Color c2 = Color.FromArgb(gray, gray, gray);
                    result.SetPixel(x, y, c2);
                }
            }

            return result;
        }
    }
}
