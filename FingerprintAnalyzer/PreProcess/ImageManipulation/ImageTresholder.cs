using FingerprintAnalyzer.PreProcess.ImageManipulation.ImageTools;
using System.Drawing;

namespace FingerprintAnalyzer.PreProcess.ImageManipulation
{
    /// <summary>
    /// Transforms image into Black-White representation using customisable treshold level
    /// </summary>
    class ImageTresholder : AImageManipulator
    {
        public static ImageTresholder Instance { get; } = new ImageTresholder();

        private ImageTresholder() { }

        public override Image transform(Image original, dynamic parameters = null)
        {
            ImageMatrix matrix = new ImageMatrix(new Bitmap(original));

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    var pixel = matrix[x, y];
                    pixel.Luminance = pixel.Luminance < parameters.TresholdLevel ? 0 : 255;
                }
            }

            return matrix.ToImage;
        }
    }
}
