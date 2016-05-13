using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.PreProcess.ImageManipulation
{

    /// <summary>
    /// Image manipulator which uses sciencey magic to change equalized image into a skeletized bitmap
    /// </summary>
    class ImageSkeletonizer : AImageManipulator
    {
        public static ImageSkeletonizer Instance { get; } = new ImageSkeletonizer();


        private ImageSkeletonizer() { }

        public override Image transform(Image original, dynamic parameters = null)
        {
            Bitmap origBitmap = new Bitmap(original);
            int[,] M = createBinaryMatrix(origBitmap);

            int min, X, Y;

            X = M.GetLength(0) - 1;
            Y = M.GetLength(1) - 1;
            min = findMin(M, X, Y);

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
                    if (M[y, x] >= 0)
                    {
                        continue;
                    }
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

            return createSkeleton(M, X, Y);
        }

        private int findMin(int[,] M, int X, int Y)
        {
            int min = 0;

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

            return min;
        }

        private int[,] createBinaryMatrix(Bitmap image)
        {
            int[,] M = new int[image.Height, image.Width];

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color c = image.GetPixel(x, y);
                    M[y, x] = (c.R != 0) ? 1 : 0;
                }
            }
            return M;
        }

        private Bitmap createSkeleton(int[,] M, int X, int Y)
        {

            Bitmap skeleton = new Bitmap(M.GetLength(0), M.GetLength(1));
            for (int y = 1; y < Y; y++)
            {
                for (int x = 1; x < X; x++)
                {
                    int gray = M[y, x] < 0 ? 0 : 255;
                    
                    Color c2 = Color.FromArgb(gray, gray, gray);
                    skeleton.SetPixel(x, y, c2);
                }
            }
            return skeleton;
        }
    }
}
