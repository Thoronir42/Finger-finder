using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.ImageManipulation
{
    /// <summary>
    /// Equalizes image, which results in luminancy being distributed more evenly over the histogram
    /// </summary>
    class ImageEqualizer : AImageManipulator
    {
        public override Image transform(Image original)
        {
            Bitmap origBitmap = new Bitmap(original);
            Bitmap result = new Bitmap(original.Width, original.Height);

            int max, min;
            int[] histogram = new int[256];

            scanImage(origBitmap, histogram, out max, out min);


            int surface = original.Width * original.Height;
            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    int luminance = colorToLuminance(origBitmap.GetPixel(x, y));
                    double sum = 0;
                    
                    for (int n = 0; n < luminance; n++)
                    {
                        sum += histogram[n] / (double)surface;
                    }

                    int gray = (int)((max - min) * sum + min);


                    Color color = Color.FromArgb(gray, gray, gray);
                    result.SetPixel(x, y, color);
                }
            }

            return result;
        }

        private void scanImage(Bitmap image, int[] histogram, out int max, out int min)
        {
            max = 0;
            min = 255;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    int luminance = colorToLuminance(image.GetPixel(x, y));

                    histogram[luminance]++;

                    if (max < luminance)
                        max = luminance;
                    if (min > luminance)
                        min = luminance;
                }
            }
        }
    }
}
