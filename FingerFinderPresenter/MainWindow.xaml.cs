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
using FingerprintAnalyzer.Model;
using FingerprintAnalyzer.Analyze;

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
            var selectedIndex = tabControl_fingerprintDrawer.SelectedIndex;
            drawFingerprint((AnalyzerStages)selectedIndex);
        }

        /// <summary>
        /// Import obrazku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.tif, *.png) | *.jpg; *.jpeg; *.tif; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                Console.WriteLine(openFileDialog.FileName);

                try
                {
                    System.Drawing.Image fingerprint = System.Drawing.Image.FromFile(openFileDialog.FileName);

                    this.Analyzer.createNewFromImage(fingerprint);
                    MenuItem_save.IsEnabled = true;

                    this.changeStage(AnalyzerStages.Original);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }       
        }

        private void changeStage(AnalyzerStages newStage)
        {
            // TODO: refactor
            int currentStage = tabControl_fingerprintDrawer.SelectedIndex;

            button_prevStage.IsEnabled = newStage > AnalyzerStages.Original;
            button_nextStage.IsEnabled = newStage < AnalyzerStages.Skeletonized;


            // Stage is going forward - create new stage if newStage is a valid one and draw is
            switch (newStage) {
                default: return;
                case AnalyzerStages.Original:
                    break;
                case AnalyzerStages.Equalized:
                    Analyzer.transformEqualization();
                    break;
                case AnalyzerStages.Tresholded:
                    Analyzer.transformTresholding(160); // TODO: user controls
                    break;
                case AnalyzerStages.Skeletonized:
                    Analyzer.transformSkeletonize();
                    break;
            }
            this.drawFingerprint(newStage);
            tabControl_fingerprintDrawer.SelectedIndex = (int)newStage;
        }

        private void drawFingerprint(AnalyzerStages stage)
        {
            var currentImage = Analyzer.getImageFor(stage);

            if (currentImage == null)
            {
                SolidColorBrush fill = new SolidColorBrush(Color.FromRgb(240,80,160));
                canvas.Background = fill;
                //image_fingerprint;
                return;
            }

            SolidColorBrush fillW = new SolidColorBrush(Color.FromRgb(255,255,255));
            canvas.Background = fillW;

            var bmp = FiFiPrToolkit.imageToRenderTargetBitmap(currentImage, (int)canvas.ActualWidth, (int)canvas.ActualHeight);

            image_fingerprint.Source = bmp;
        }

        private void MenuItem_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_save_Click(object sender, RoutedEventArgs e)
        {
            Analyzer.mockAnalyzeAndClassify();

            SaveFileDialog saver = new SaveFileDialog();
            saver.Filter = "Otisk prstu (*.fpr) | *.fpr;";
            if(saver.ShowDialog() != true)
            {
                return;
            }
            Analyzer.saveToFile(saver.FileName);
        }
    }
}
