using FingerprintAnalyzer;
using FingerprintAnalyzer.Analyze;
using FingerprintAnalyzer.Model;
using FingerprintAnalyzer.PreProcess;
using FingerprintAnalyzer.PreProcess.Sequences;
using System;
using System.Windows.Media;

namespace FingerFinderPresenter.ViewModel
{
    partial class FingerFinder : BaseModel
    {
        private int selectedTab = 0;
        private SolidColorBrush canvasBackground;
        private ImageSource fingerprintImageSource;

        private int tresholdLevel = 160;

        public Preprocesor Preprocesor { get; } = new Preprocesor();
        public Analyzer Analyzer { get; } = new Analyzer();

        public int SelectedTab { get { return selectedTab; } set { selectedTab = value; NotifyPropertyChanged(); selectedIndexChanged(value); } }

        public SolidColorBrush CanvasBackground { get { return canvasBackground; } set { canvasBackground = value; NotifyPropertyChanged(); } }
        public ImageSource FingerprintImageSource { get { return fingerprintImageSource; } set { fingerprintImageSource = value; NotifyPropertyChanged(); } }

        public int TresholdLevel { get { return tresholdLevel; } set { tresholdLevel = value; NotifyPropertyChanged(); } }

        public int CanvasWidth { get; } = 350;
        public int CanvasHeight { get; } = 350;

        public FingerFinder()
        {
            InitializeCommands();
            InitializeStages();
            InitializePostProcess();
            Preprocesor.StageChanged += StageChanged;
        }

        private void drawFingerprint(System.Drawing.Image image)
        {
            if (image == null)
            {
                CanvasBackground = new SolidColorBrush(Color.FromRgb(240, 80, 160));
                return;
            }
            CanvasBackground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            var bmp = GenericToolkit.imageToRenderTargetBitmap(image, CanvasWidth, CanvasHeight);
            FingerprintImageSource = bmp;
        }

        private void selectedIndexChanged(int index)
        {
            var image = Preprocesor.getImageFor(index);
            drawFingerprint(image);
        }
    }

}
