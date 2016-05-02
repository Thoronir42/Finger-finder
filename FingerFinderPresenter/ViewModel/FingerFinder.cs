using FingerprintAnalyzer;
using FingerprintAnalyzer.Analyze;
using FingerprintAnalyzer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerFinderPresenter.ViewModel
{
    class FingerFinder : BaseModel
    {
        private Analyzer analyzer = new Analyzer();

        public Analyzer Analyzer
        {
            get { return analyzer; }
            private set
            {
                analyzer = value;
            }
        }

        public RelayCommand PreviousStage { get; set; }
        public RelayCommand NextStage { get; set; }

        public FingerFinder()
        {

            PreviousStage = new RelayCommand(
                o => { analyzer.CurrentStage--; },
                o => analyzer.CurrentStage > AnalyzerStages.Original
                );
            NextStage = new RelayCommand(
                o => { analyzer.CurrentStage++; },
                o => analyzer.CurrentStage < AnalyzerStages.Skeletonized
                );
        }
    }

    
}
