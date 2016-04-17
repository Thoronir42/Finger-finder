using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FingerFinderPresenter
{
    class FiFiPrToolkit
    {
        public static RenderTargetBitmap imageToRenderTargetBitmap(Image originalImage, int reqWidth, int reqHeight)
        {
            BitmapImage fingerprint = new BitmapImage();

            using (MemoryStream memory = new MemoryStream())
            {
                originalImage.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                fingerprint.BeginInit();
                fingerprint.StreamSource = memory;
                fingerprint.CacheOption = BitmapCacheOption.OnLoad;
                fingerprint.EndInit();

            }

            DrawingVisual drawingVisual = new DrawingVisual();
            var draw = drawingVisual.RenderOpen();
            draw.DrawImage(fingerprint, new Rect(0, 0, fingerprint.PixelWidth, fingerprint.PixelHeight));
            draw.Close();

            RenderTargetBitmap bmp = new RenderTargetBitmap(reqWidth, reqHeight, 120, 96, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);

            return bmp;
        }
    }
}
