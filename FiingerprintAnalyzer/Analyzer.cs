using System;
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
        private Image fingerpintEqualization;
        private Image fingerpintTresholding;
        private Image fingerpintSkeleton;

        public Image FingerprintOriginal
        {
            get { return fingerprintOriginal; }
            set
            {
                fingerprintOriginal = value;
                fingerpintEqualization = doHistogramEqualization(value);
                fingerpintTresholding = doTresholding(fingerpintEqualization);
                fingerpintSkeleton = createFingerprintSkeleton(fingerpintTresholding);

            }
        }
        public Image FingerprintSkeleton { get { return this.fingerpintSkeleton; } }

        private Image createFingerprintSkeleton(Image original)
        {
            Bitmap original_b = new Bitmap(original);
            Bitmap skeleton = new Bitmap(original.Width, original.Height);

            int min, X = original.Width - 1, Y = original.Height - 1;
            int[,] M = new int[original.Height, original.Width];

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color c = original_b.GetPixel(x, y);
                    M[y, x] = (c.R != 0) ? 1 : 0;
                }
            }

            for (int y = 1; y < Y; y++)
            {
                for (int x = 1; x < X; x++)
                {
                    if (M[y, x] == 1)
                    {
                        min = M[y - 1, x - 1];
                        if (M[y - 1, x] < min) min = M[y - 1, x];
                        if (M[y - 1, x + 1] < min) min = M[y - 1, x + 1];
                        if (M[y, x - 1] < min) min = M[y, x - 1];
                        M[y, x] = min + 1;
                    }
                }
            }


            for (int y = Y - 1; y > 0; y--)
            {
                for (int x = X - 1; x > 0; x--)
                {
                    if (M[y, x] > 1)
                    {
                        min = M[y, x + 1];
                        if (M[y + 1, x - 1] < min) min = M[y + 1, x - 1];
                        if (M[y + 1, x] < min) min = M[y + 1, x];
                        if (M[y + 1, x + 1] < min) min = M[y + 1, x + 1];
                        if (min + 1 < M[y, x]) M[y, x] = min + 1;
                    }
                }
            }

            for (int y = 1; y < Y; y++)
            {
                for (int x = 1; x < X; x++)
                {
                    if (M[y, x] > 0 && Math.Abs(M[y - 1, x]) <= M[y, x] && Math.Abs(M[y, x - 1]) <= M[y, x] &&
                    (M[y + 1, x] <= M[y, x] || M[y - 1, x] < 0) && (M[y, x + 1] <= M[y, x] || M[y, x - 1] < 0))
                        M[y, x] *= -1;
                }
            }


            for (int y = Y - 1; y > 0; y--)
            {
                for (int x = X - 1; x > 0; x--)
                {
                    if (M[y, x] > 0 && ((M[y + 1, x] < 0 && Math.Abs(M[y - 1, x]) > M[y, x]) ||
                    (M[y, x + 1] < 0 && Math.Abs(M[y, x - 1]) > M[y, x])))
                        M[y, x] *= -1;
                }
            }

            int transitions, greater;
            for (int y = 1; y < Y; y++)
            {
                for (int x = 1; x < X; x++)
                {
                    if (M[y, x] < 0)
                    {
                        greater = 0;
                        transitions = 0;
                        if (M[y - 1, x - 1] < M[y, x]) greater = 1;
                        if (M[y - 1, x - 1] < 0 && M[y - 1, x] >= 0) transitions++;
                        if (M[y - 1, x] < M[y, x]) greater = 1;
                        if (M[y - 1, x] < 0 && M[y - 1, x + 1] >= 0) transitions++;
                        if (M[y - 1, x + 1] < M[y, x]) greater = 1;
                        if (M[y - 1, x + 1] < 0 && M[y, x + 1] >= 0) transitions++;
                        if (M[y, x - 1] < M[y, x]) greater = 1;
                        if (M[y, x + 1] < 0 && M[y + 1, x + 1] >= 0) transitions++;
                        if (M[y, x + 1] < M[y, x]) greater = 1;
                        if (M[y + 1, x + 1] < 0 && M[y + 1, x] >= 0) transitions++;
                        if (M[y + 1, x - 1] < M[y, x]) greater = 1;
                        if (M[y + 1, x] < 0 && M[y + 1, x - 1] >= 0) transitions++;
                        if (M[y + 1, x] < M[y, x]) greater = 1;
                        if (M[y + 1, x - 1] < 0 && M[y, x - 1] >= 0) transitions++;
                        if (M[y + 1, x + 1] < M[y, x]) greater = 1;
                        if (M[y, x - 1] < 0 && M[y - 1, x - 1] >= 0) transitions++;
                        if (greater == 1 && transitions < 2) M[y, x] *= -1;
                    }
                }
            }

            for (int y = Y - 1; y > 0; y--)
            {
                for (int x = X - 1; x > 0; x--)
                {
                    if (M[y, x] < 0)
                    {
                        greater = 0;
                        transitions = 0;
                        if (M[y - 1, x - 1] < M[y, x]) greater = 1;
                        if (M[y - 1, x - 1] < 0 && M[y - 1, x] >= 0) transitions++;
                        if (M[y - 1, x] < M[y, x]) greater = 1;
                        if (M[y - 1, x] < 0 && M[y - 1, x + 1] >= 0) transitions++;
                        if (M[y - 1, x + 1] < M[y, x]) greater = 1;
                        if (M[y - 1, x + 1] < 0 && M[y, x + 1] >= 0) transitions++;
                        if (M[y, x - 1] < M[y, x]) greater = 1;
                        if (M[y, x + 1] < 0 && M[y + 1, x + 1] >= 0) transitions++;
                        if (M[y, x + 1] < M[y, x]) greater = 1;
                        if (M[y + 1, x + 1] < 0 && M[y + 1, x] >= 0) transitions++;
                        if (M[y + 1, x - 1] < M[y, x]) greater = 1;
                        if (M[y + 1, x] < 0 && M[y + 1, x - 1] >= 0) transitions++;
                        if (M[y + 1, x] < M[y, x]) greater = 1;
                        if (M[y + 1, x - 1] < 0 && M[y, x - 1] >= 0) transitions++;
                        if (M[y + 1, x + 1] < M[y, x]) greater = 1;
                        if (M[y, x - 1] < 0 && M[y - 1, x - 1] >= 0) transitions++;
                        if (greater == 1 && transitions < 2) M[y, x] *= -1;
                    }
                }
            }

            for (int y = 1; y < Y; y++)
            {
                for (int x = 1; x < X; x++) {

                    Color c2;                   

                    if (M[y, x] < 0)
                    {
                        c2 = Color.FromArgb(0, 0, 0);
                    }
                    else
                    {
                        c2 = Color.FromArgb(255, 255, 255);
                    }

                    skeleton.SetPixel(x, y, c2);
                }
            }

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

        public Image doTresholding(Image original)
        {
            Bitmap original_b = new Bitmap(original);
            Bitmap tresholding = new Bitmap(original.Width, original.Height);
            int color;

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color c = original_b.GetPixel(x, y);
                    color = (c.R < 128) ? 0 : 255;

                    Color c2 = Color.FromArgb(color, color, color);
                    tresholding.SetPixel(x, y, c2);
                }
            }

            return tresholding;
        }


        public Image getImage(int selectedIndex)
        {
            if(selectedIndex == 0)
            {
                return this.FingerprintOriginal;
            }
            else if (selectedIndex == 1)
            {
                return this.fingerpintEqualization;
            }
            else if (selectedIndex == 2)
            {
                return this.fingerpintTresholding;
            }
            else {
                return this.FingerprintSkeleton;
            }
        }
    }
}
