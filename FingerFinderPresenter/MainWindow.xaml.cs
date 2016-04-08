using System;
using System.Windows;
using FingerprintAnalyzer;
using Microsoft.Win32;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing.Imaging;

namespace FingerFinderPresenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected Analyzer Analyzer { get; set; } = new Analyzer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void tabControl_fingerprintDrawer_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Console.WriteLine(sender.ToString());
            drawFingerprint();
        }

        /// <summary>
        /// Import obrazku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Console.WriteLine(openFileDialog.FileName);

                try
                {
                    System.Drawing.Image fingerprint = System.Drawing.Image.FromFile(openFileDialog.FileName);
                    this.Analyzer.FingerprintOriginal = fingerprint;
                    this.drawFingerprint();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }
                
        }

        private void drawFingerprint()
        {
            System.Drawing.Image fingerprintIm = this.Analyzer.getImage(tabControl_fingerprintDrawer.SelectedIndex);

            if (fingerprintIm == null)
            {
                SolidColorBrush fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("HotPink"));
                canvas.Background = fill;

                return;
            }

            BitmapImage fingerprint = new BitmapImage();

            using (MemoryStream memory = new MemoryStream())
            {
                fingerprintIm.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                fingerprint.BeginInit();
                fingerprint.StreamSource = memory;
                fingerprint.CacheOption = BitmapCacheOption.OnLoad;
                fingerprint.EndInit();
                
            }

            SolidColorBrush fillW = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
            canvas.Background = fillW;

            DrawingVisual drawingVisual = new DrawingVisual();
            var draw = drawingVisual.RenderOpen();
            draw.DrawImage(fingerprint, new Rect(0, 0, fingerprint.PixelWidth, fingerprint.PixelHeight));
            draw.Close();

            RenderTargetBitmap bmp = new RenderTargetBitmap((int)canvas.ActualWidth, (int)canvas.ActualHeight, 120, 96, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);

            Image image = new Image();
            image.Source = bmp;
            canvas.Children.Add(image);
        }

        private void MenuItem_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
