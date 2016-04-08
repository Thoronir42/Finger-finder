﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer
{
    public partial class Analyzer
    {
        private Image fingerprintOriginal;
        private Image fingerpintSkeleton;

        public Image FingerprintOriginal
        {
            get { return fingerprintOriginal; }
            set
            {
                fingerprintOriginal = value;
                fingerpintSkeleton = createFingerprintSkeleton(value);

            }
        }
        public Image FingerprintSkeleton { get { return this.fingerpintSkeleton; } }

        private Image createFingerprintSkeleton(Image original)
        {
            Image skeleton;
            skeleton = doHistogramEqualization(original);

            return skeleton;
        }

        /// <summary>
        /// Provede ekvalizaci histogramu, slouží k vyrovnání jasově nerovnoměrného obrazu otisku prstu
        /// </summary>
        /// <param name="original">Původní snímek</param>
        /// <returns></returns>
        private Image doHistogramEqualization(Image original)
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
                    int luminance = (int)Math.Round(0.299 * c.R + 0.587 * c.G + 0.114 * c.B);
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
                    int luminance = (int)Math.Round(0.299 * c.R + 0.587 * c.G + 0.114 * c.B);

                    double sum = 0;
                    int p0 = original.Width * original.Height;
                    for (int n = 0; n < luminance; n++)
                    {
                        sum += histogram[n] / (double) p0;
                    }

                    int g = (int)((max - min) * sum + min);

                    
                    Color c2 = Color.FromArgb(g, g, g);
                    equalization.SetPixel(x, y, c2);
                }
            }

            return equalization;
        }


        public Image getImage(int selectedIndex)
        {
            if(selectedIndex == 0)
            {
                return this.FingerprintOriginal;
            } else
            {
                return this.FingerprintSkeleton;
            }
        }
    }
}
