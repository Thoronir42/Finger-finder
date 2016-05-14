using FingerprintAnalyzer.PreProcess.ImageManipulation.ImageTools;
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
            ImageMatrix matrix = new ImageMatrixSign(origBitmap);

            int min, X, Y;

            X = matrix.Width - 1;
            Y = matrix.Height - 1;

            min = findMin(matrix, X, Y);

            negateTransform(matrix, X, Y);

            compareForthTransform(matrix, X, Y);
            compareBackTransform(matrix, X, Y);

            return matrix.ToImage;
        }

        private int findMin(ImageMatrix M, int X, int Y)
        {
            ImageMatrix.Pixel min = null;

            for (int y = 1; y < Y; y++)
            {
                for (int x = 1; x < X; x++)
                {
                    ImageMatrix.Pixel pixel = M[x, y];
                    if (pixel.Luminance == 1)
                    {
                        min = pixel[Direction.TopLeft];
                        if (pixel[Direction.Top] < min) min = pixel[Direction.Top];
                        if (pixel[Direction.TopRight] < min) min = pixel[Direction.TopRight];
                        if (pixel[Direction.Left] < min) min = pixel[Direction.Left];
                        pixel.Luminance = min.Luminance + 1;
                    }
                }
            }

            for (int y = Y - 1; y > 0; y--)
            {
                for (int x = X - 1; x > 0; x--)
                {
                    ImageMatrix.Pixel pixel = M[x, y];
                    if (pixel.Luminance > 1)
                    {
                        min = pixel[Direction.Right];
                        if (pixel[Direction.BottomLeft] < min) min = pixel[Direction.BottomLeft];
                        if (pixel[Direction.Bottom] < min) min = pixel[Direction.Bottom];
                        if (pixel[Direction.BottomRight] < min) min = pixel[Direction.BottomRight];
                        if (min.Luminance + 1 < pixel.Luminance) pixel.Luminance = min.Luminance + 1;
                    }
                }
            }

            if(min == null)
            {
                return 0;
            }
            return min.Luminance;
        }

        private void negateTransform(ImageMatrix M, int X, int Y)
        {
            for (int y = 1; y < Y; y++)
            {
                for (int x = 1; x < X; x++)
                {
                    ImageMatrix.Pixel pixel = M[x, y];
                    if (pixel > 0 && Math.Abs(pixel[Direction.Top]) <= pixel && Math.Abs(pixel[Direction.Left]) <= pixel &&
                    (pixel[Direction.Bottom] <= pixel || pixel[Direction.Top] < 0) && (pixel[Direction.Right] <= pixel || pixel[Direction.Left] < 0))
                        pixel.Luminance *= -1;
                }
            }


            for (int y = Y - 1; y > 0; y--)
            {
                for (int x = X - 1; x > 0; x--)
                {
                    ImageMatrix.Pixel pixel = M[x, y];
                    if (pixel > 0 && ((pixel[Direction.Bottom] < 0 && Math.Abs(pixel[Direction.Top]) > pixel) ||
                    (pixel[Direction.Right] < 0 && Math.Abs(pixel[Direction.Left]) > pixel)))
                        pixel.Luminance *= -1;
                }
            }
        }

        private void compareForthTransform(ImageMatrix M, int X, int Y)
        {
            int transitions, greater;
            for (int y = 1; y < Y; y++)
            {
                for (int x = 1; x < X; x++)
                {
                    ImageMatrix.Pixel pixel = M[x, y];
                    if (pixel >= 0)
                    {
                        continue;
                    }
                    greater = 0;
                    transitions = 0;
                    if (pixel[Direction.TopLeft] < pixel) greater = 1;
                    if (pixel[Direction.TopLeft] < 0 && pixel[Direction.Top] >= 0) transitions++;
                    if (pixel[Direction.Top] < pixel) greater = 1;
                    if (pixel[Direction.Top] < 0 && pixel[Direction.TopRight] >= 0) transitions++;
                    if (pixel[Direction.TopRight] < pixel) greater = 1;
                    if (pixel[Direction.TopRight] < 0 && pixel[Direction.Right] >= 0) transitions++;
                    if (pixel[Direction.Left] < pixel) greater = 1;
                    if (pixel[Direction.Right] < 0 && pixel[Direction.BottomRight] >= 0) transitions++;
                    if (pixel[Direction.Right] < pixel) greater = 1;
                    if (pixel[Direction.BottomRight] < 0 && pixel[Direction.Bottom] >= 0) transitions++;
                    if (pixel[Direction.BottomLeft] < pixel) greater = 1;
                    if (pixel[Direction.Bottom] < 0 && pixel[Direction.BottomLeft] >= 0) transitions++;
                    if (pixel[Direction.Bottom] < pixel) greater = 1;
                    if (pixel[Direction.BottomLeft] < 0 && pixel[Direction.Left] >= 0) transitions++;
                    if (pixel[Direction.BottomRight] < pixel) greater = 1;
                    if (pixel[Direction.Left] < 0 && pixel[Direction.TopLeft] >= 0) transitions++;
                    if (greater == 1 && transitions < 2) pixel.Luminance *= -1;
                }
            }
        }

        private void compareBackTransform(ImageMatrix M, int X, int Y)
        {
            int greater, transitions;
            for (int y = Y - 1; y > 0; y--)
            {
                for (int x = X - 1; x > 0; x--)
                {
                    ImageMatrix.Pixel pixel = M[x, y];

                    if (pixel >= 0)
                    {
                        continue;
                    }
                    greater = 0;
                    transitions = 0;
                    if (pixel[Direction.TopLeft] < pixel) greater = 1;
                    if (pixel[Direction.TopLeft] < 0 && pixel[Direction.Top] >= 0) transitions++;
                    if (pixel[Direction.Top] < pixel) greater = 1;
                    if (pixel[Direction.Top] < 0 && pixel[Direction.TopRight] >= 0) transitions++;
                    if (pixel[Direction.TopRight] < pixel) greater = 1;
                    if (pixel[Direction.TopRight] < 0 && pixel[Direction.Right] >= 0) transitions++;
                    if (pixel[Direction.Left] < pixel) greater = 1;
                    if (pixel[Direction.Right] < 0 && pixel[Direction.BottomRight] >= 0) transitions++;
                    if (pixel[Direction.Right] < pixel) greater = 1;
                    if (pixel[Direction.BottomRight] < 0 && pixel[Direction.Bottom] >= 0) transitions++;
                    if (pixel[Direction.BottomLeft] < pixel) greater = 1;
                    if (pixel[Direction.Bottom] < 0 && pixel[Direction.BottomLeft] >= 0) transitions++;
                    if (pixel[Direction.Bottom] < pixel) greater = 1;
                    if (pixel[Direction.BottomLeft] < 0 && pixel[Direction.Left] >= 0) transitions++;
                    if (pixel[Direction.BottomRight] < pixel) greater = 1;
                    if (pixel[Direction.Left] < 0 && pixel[Direction.TopLeft] >= 0) transitions++;
                    if (greater == 1 && transitions < 2) pixel.Luminance *= -1;

                }
            }
        }
    }
}
