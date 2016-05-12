using FingerprintAnalyzer.Analyze;
using FingerprintAnalyzer.PreProcess.Sequences;
using System;
using System.Windows;

namespace FingerFinderPresenter.ViewModel
{
    partial class FingerFinder
    {
        public RelayCommand PreviousStage { get; set; }
        public RelayCommand NextStage { get; set; }
        public RelayCommand PreviewChanges { get; set; }

        public RelayCommand CmdChooseSequence { get; set; }


        private Visibility sequenceOne, sequenceTwo;
        public Visibility SequenceOne { get { return sequenceOne; } set { sequenceOne = value; NotifyPropertyChanged(); } }
        public Visibility SequenceTwo { get { return sequenceTwo; } set { sequenceTwo = value; NotifyPropertyChanged(); } }

        private void InitializeStages()
        {
            PreviousStage = new RelayCommand(
            o => { Analyzer.stepBackward(); },
                o => Analyzer.canStepBackward()
                );
            NextStage = new RelayCommand(
                o => { Analyzer.stepForward(); },
                o => Analyzer.canStepForward()
                );
            PreviewChanges = new RelayCommand(
                o => { previewChanges(); },
                o => Analyzer.PreviewAvailable
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

            SequenceOne = Visibility.Visible;
            SequenceTwo = Visibility.Collapsed;

        }

        private void ChooseSequence(int sequence)
        {
            if(sequence == 1)
            {
                SequenceOne = Visibility.Visible;
                SequenceTwo = Visibility.Collapsed;
            } else
            {
                SequenceOne = Visibility.Collapsed;
                SequenceTwo = Visibility.Visible;
            }
        }

        private void Analyzer_StageChanged(Analyzer sender, StageChangedEventArgs e)
        {
            //Console.WriteLine($"Stage changed from {e.OldStage} to {e.NewStage}");
            SelectedTab = stageToTabIndex(e.NewStage);
        }

        private int stageToTabIndex(Stage stage)
        {
            // TODO wtf??

            if (stage.Equals(Stage.Original))
            {
                return 0;
            }
            if (stage.Equals(SkeletoniserStage.Equalised))
            {
                return 1;
            }
            if (stage.Equals(SkeletoniserStage.Tresholded))
            {
                return 2;
            }
            if (stage.Equals(Stage.Final))
            {
                return 3;
            }
            /*
            switch (stage)
            {
                case SkeletiniserStage..Finalised: stage = Analyzer.Stages.Skeletonized; break;
                case Analyzer.Stages.Standby: stage = Analyzer.Stages.Original; break;
            }
            */
            return 0;
        }
    }
}
