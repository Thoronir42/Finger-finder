using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.ImageManipulation
{
    class ImageEqualizer : AImageManipulator
    {
        public override Image transform(Image original)
        {
            Bitmap original_b = new Bitmap(original);
            Bitmap equalization = new Bitmap(original.Width, original.Height);
            int[] histogram = new int[256];
            int max = 0;
            int min = 255;

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color c = original_b.GetPixel(x, y);
                    int luminance = (int)Math.Round(LUMINANCY_COEFICIENT_RED * c.R + LUMINANCY_COEFICIENT_GREEN * c.G + LUMINANCY_COEFICIENT_BLUE * c.B);
                    histogram[luminance]++;
                    if (max < luminance)
                        max = luminance;
                    if (min > luminance)
                        min = luminance;
                }
            }

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color c = original_b.GetPixel(x, y);
                    int luminance = (int)Math.Round(LUMINANCY_COEFICIENT_RED * c.R + LUMINANCY_COEFICIENT_GREEN * c.G + LUMINANCY_COEFICIENT_BLUE * c.B);

                    double sum = 0;
                    int p0 = original.Width * original.Height;
                    for (int n = 0; n < luminance; n++)
                    {
                        sum += histogram[n] / (double)p0;
                    }

                    int g = (int)((max - min) * sum + min);


                    Color c2 = Color.FromArgb(g, g, g);
                    equalization.SetPixel(x, y, c2);
                }
            }

            return equalization;
        }
    }
}
