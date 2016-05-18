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

        public Preprocesor Preprocesor { get; } = new Preprocesor();
        public Analyzer Analyzer { get; } = new Analyzer();

        

        public Image CurrentImage
        {
            get { return currentImage; }
            set
            {
                currentImage = value;
                NotifyPropertyChanged();
            }
        }

        public FingerFinder()
        {
            InitializeCommands();
            InitializePreprocess();
            InitializeAnalyze();
            InitializeTabVisibility();
            Preprocesor.StageChanged += StageChanged;
        }
    }

}
