using FingerprintAnalyzer;
using FingerprintAnalyzer.Analyze;
using FingerprintAnalyzer.Model;
using FingerprintAnalyzer.PreProcess;
using FingerprintAnalyzer.PreProcess.Sequences;
using System;
using System.Drawing;
using System.Windows.Media;

namespace FingerFinderPresenter.ViewModel
{
    partial class FingerFinder : BaseModel
    {
        private SolidColorBrush canvasBackground;

        private Image currentImage;
        private ImageSource fingerprintImageSource;

        public Preprocesor Preprocesor { get; } = new Preprocesor();
        public Analyzer Analyzer { get; } = new Analyzer();

        

        public SolidColorBrush CanvasBackground { get { return canvasBackground; } set { canvasBackground = value; NotifyPropertyChanged(); } }

        public Image CurrentlyRenderedImage
        {
            get { return currentImage; }
            set
            {
                currentImage = value;

                if (value == null)
                {
                    CanvasBackground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(240, 80, 160));
                    return;
                }
                CanvasBackground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));

                FingerprintImageSource = GenericToolkit.imageToRenderTargetBitmap(value, CanvasWidth, CanvasHeight);
            }
        }
        public ImageSource FingerprintImageSource { get { return fingerprintImageSource; } set { fingerprintImageSource = value; NotifyPropertyChanged(); } }

        public int CanvasWidth { get; } = 350;
        public int CanvasHeight { get; } = 350;

        public FingerFinder()
        {
            InitializeCommands();
            InitializePreprocess();
            InitializePostProcess();
            InitializeTabVisibility();
            Preprocesor.StageChanged += StageChanged;
        }

        private void selectedIndexChanged(int index)
        {
            CurrentlyRenderedImage = Preprocesor.getImageFor(Preprocesor.CurrentStage);
        }
    }

}
