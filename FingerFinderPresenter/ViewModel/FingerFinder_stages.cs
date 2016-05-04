using FingerprintAnalyzer.Analyze;
using System;

namespace FingerFinderPresenter.ViewModel
{
    partial class FingerFinder
    {
        private void previousStage()
        {
            changeStage(Analyzer.CurrentStage - 1, true);
        }

        private void nextStage()
        {
            changeStage(Analyzer.CurrentStage + 1);
        }

        private void changeStage(Analyzer.Stages newStage, bool reverting = false)
        {
            // TODO: refactor
            int currentStage = SelectedIndex;


            // Stage is going forward - create new stage if newStage is a valid one and draw is
            switch (newStage)
            {
                default: return;
                case Analyzer.Stages.Original:
                    Analyzer.CurrentStage = Analyzer.Stages.Original;
                    break;
                case Analyzer.Stages.Equalized:
                    Analyzer.transformEqualization();
                    break;
                case Analyzer.Stages.Tresholded:
                    Analyzer.transformTresholding(TresholdLevel); // TODO: user controls
                    break;
                case Analyzer.Stages.Skeletonized:
                    Analyzer.transformSkeletonize();
                    break;
            }
            this.drawFingerprint(newStage);
            SelectedIndex = (int)newStage;
        }

        private void Analyzer_StageChanged(Analyzer sender, StageChangedEventArgs e)
        {
            Console.WriteLine($"Stage changed from {e.OldStage} to {e.NewStage}");
            SelectedIndex = stageToTabIndex(e.NewStage);
        }

        private int stageToTabIndex(Analyzer.Stages stage)
        {

            switch (stage)
            {
                case Analyzer.Stages.Finalised: stage = Analyzer.Stages.Skeletonized; break;
                case Analyzer.Stages.Standby: stage = Analyzer.Stages.Original; break;
            }
            return (int)stage;
        }
    }
}
