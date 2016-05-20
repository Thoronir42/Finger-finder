using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FingerFinderPresenter.ViewModel.Converters
{
    class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine("Converting " + value);
            if (value == null)
            {
                Console.Error.WriteLine($"Conversion failed on null refference pointer");
                return Binding.DoNothing;
            }
            try
            {
                BitmapImage bitmapimage = new BitmapImage();
                using (MemoryStream memory = new MemoryStream())
                {
                    System.Drawing.Image original = (value as System.Drawing.Image);
                    original.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;

                    bitmapimage.BeginInit();
                    bitmapimage.StreamSource = memory;
                    bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapimage.EndInit();
                }
                return bitmapimage;
            }
            catch(Exception)
            {
                Console.Error.WriteLine($"Invalid ImageSourceConverter usage: Attepmted conversion {value.GetType()} => {targetType}");
                return Binding.DoNothing;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
