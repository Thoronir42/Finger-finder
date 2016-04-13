using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.Manipulators
{
    class ImageTresholder : AImageManipulator
    {
        public int TresholdLevel { get; set; } = 128;

        public override Image transform(Image original)
        {
            Bitmap original_b = new Bitmap(original);
            Bitmap tresholding = new Bitmap(original.Width, original.Height);
            int color;

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color c = original_b.GetPixel(x, y);
                    color = (c.R < TresholdLevel) ? 0 : 255;

                    Color c2 = Color.FromArgb(color, color, color);
                    tresholding.SetPixel(x, y, c2);
                }
            }

            return tresholding;
        }
    }
}
