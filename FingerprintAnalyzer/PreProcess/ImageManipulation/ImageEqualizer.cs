using FingerprintAnalyzer.PreProcess.ImageManipulation.ImageTools;
using System.Drawing;

namespace FingerprintAnalyzer.PreProcess.ImageManipulation
{
    /// <summary>
    /// Equalizes image, which results in luminancy being distributed more evenly over the histogram
    /// </summary>
    class ImageEqualizer : AImageManipulator
    {
        public static ImageEqualizer Instance { get; } = new ImageEqualizer();


        private ImageEqualizer() { }

        public override Image transform(Image original, dynamic parameters = null)
        {
            ImageMatrix matrix = new ImageMatrix(new Bitmap(original));
            
            Histogram histogram = matrix.Histogram;
            int luminancyRange = histogram.Range;
            double surfaceArea = matrix.Width * matrix.Height;

            for (int y = 0; y < matrix.Height; y++)
            {
                for (int x = 0; x < matrix.Width; x++)
                {
                    double distribution = histogram.Distribution(matrix[x, y]) / surfaceArea;

                    matrix[x, y].Luminance = (int)(luminancyRange * distribution + histogram.Min);
                }
            }

            return matrix.ToImage;
        }
    }
}
