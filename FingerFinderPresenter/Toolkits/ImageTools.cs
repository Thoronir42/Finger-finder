using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerFinderPresenter.Toolkits
{
    class ImageTools
    {
        /// <summary>
        /// Scales provided image to largest dimensions that fill target size
        /// </summary>
        /// <param name="original">Image to be up/down-scaled</param>
        /// <param name="targetWidth">Target width for upscaling</param>
        /// <param name="targetHeight">Target height for upscaling</param>
        /// <returns></returns>
        public static Image resize(Image original, double targetWidth, double targetHeight)
        {
            double scale = Math.Min(targetWidth / original.Width, targetHeight / original.Height);
            return ResizeImage(original, (int)(original.Width * scale), (int)(original.Height * scale));
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// 
        /// Taken from http://stackoverflow.com/questions/1922040/resize-an-image-c-sharp
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        private static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
