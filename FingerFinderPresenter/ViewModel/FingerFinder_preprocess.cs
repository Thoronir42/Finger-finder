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

            CmdChooseSequence = new RelayCommand(
                o => {
                    int seq;
                    if(int.TryParse(o.ToString(), out seq))
                    {
                        Console.WriteLine(seq);
                        ChooseSequence(seq);
                    }
                }
                );
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

        private void ChooseSequence(int sequence)
        {
            ASequence select = null;
            switch (sequence)
            {
                case 1:
                    select = new SequenceSkeletisation();
                    break;
                case 2:
                    select = new SequenceSlimify();
                    break;
            }
            Preprocesor.SelectedSequence = select;
            updateSequenceVisibilities(select);

        }

        private void StageChanged(object sender, StageChangedEventArgs e)
        {
            //Console.WriteLine($"Stage changed from {e.OldStage} to {e.NewStage}");
            updateVisibilities(e.NewStage);
            SelectedTab = stageToTabIndex(e.NewStage);
            if(e.NewStage == Stage.Final)
            {
                Analyzer.FingerprintImage = Preprocesor.CurrentImage;
            }
        }
    }
}
