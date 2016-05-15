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
        private Image currentImage;
        private ImageSource fingerprintImageSource;

        public Preprocesor Preprocesor { get; } = new Preprocesor();
        public Analyzer Analyzer { get; } = new Analyzer();

        

        public Image CurrentlyRenderedImage
        {
            get { return currentImage; }
            set
            {
                currentImage = value;
                FingerprintImageSource = GenericToolkit.imageToImageSource(value, CanvasWidth, CanvasHeight);
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
    }

}
