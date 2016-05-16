using FingerprintAnalyzer.Analyze;
using FingerprintAnalyzer.PreProcess;
using FingerprintAnalyzer.PreProcess.Sequences;
using System;
using System.Collections.Generic;
using System.Windows;

namespace FingerFinderPresenter.ViewModel
{
    partial class FingerFinder
    {
        public RelayCommand PreviousStage { get; set; }
        public RelayCommand NextStage { get; set; }
        public RelayCommand PreviewChanges { get; set; }

        public RelayCommand CmdChooseSequence { get; set; }

        private int tresholdLevel = 160;
        public int TresholdLevel { get { return tresholdLevel; } set { tresholdLevel = value; NotifyPropertyChanged(); } }


        private void InitializePreprocess()
        {
            PreviousStage = new RelayCommand(
                o => { Preprocesor.stepBackward(); },
                o => Preprocesor.canStepBackward()
            );
            NextStage = new RelayCommand(
                o => { Preprocesor.stepForward(getParameters()); },
                o => Preprocesor.canStepForward()
            );
            PreviewChanges = new RelayCommand(
                o => { previewChanges(); },
                o => Preprocesor.PreviewAvailable
            );

            CmdChooseSequence = new RelayCommand( o => { ChooseSequence(o); });
        }

        private void previewChanges()
        {
            if (Preprocesor.CurrentStage.Equals(SkeletoniserStage.Equalised))
            {
                CurrentlyRenderedImage = Preprocesor.peekForward(getParameters());
            }
        }

        private dynamic getParameters()
        {
            dynamic parameters = new System.Dynamic.ExpandoObject();

            if (Preprocesor.CurrentStage.Equals(SkeletoniserStage.Equalised))
            {
                parameters.TresholdLevel = TresholdLevel;
            }
            return parameters;
        }

        private void ChooseSequence(object param)
        {
            int seq;
            if (int.TryParse(param.ToString(), out seq))
            {
                ChooseSequence(seq);
            }
        }
        private void ChooseSequence(int sequence)
        {
            ASequence select = ASequence.getSequence(sequence);
            Preprocesor.SelectedSequence = select;
            Type type = select == null ? null : select.GetType();
            updateSequenceVisibilities(type);

        }

        private void StageChanged(object sender, StageChangedEventArgs e)
        {
            //Console.WriteLine($"Stage changed from {e.OldStage} to {e.NewStage}");
            updateTabVisibilities(e.NewStage);
            SelectedTab = stageToTabIndex(e.NewStage);
            if(e.NewStage == Stage.Final)
            {
                Analyzer.SetFingerprint(Preprocesor.CurrentImage);
                CurrentlyRenderedImage = Analyzer.FingerprintImage;
            } else
            {
                CurrentlyRenderedImage = Preprocesor.CurrentImage;
            }
            if(e.OldStage == Stage.Final)
            {
                Analyzer.Clear();
            }
        }
    }
}
