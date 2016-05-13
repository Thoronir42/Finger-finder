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


        private Visibility sequenceOne, sequenceTwo;
        public Visibility SequenceOne { get { return sequenceOne; } set { sequenceOne = value; NotifyPropertyChanged(); } }
        public Visibility SequenceTwo { get { return sequenceTwo; } set { sequenceTwo = value; NotifyPropertyChanged(); } }

        private Dictionary<Stage, int> stageTabDictionary;

        private void InitializeStages()
        {
            PreviousStage = new RelayCommand(
            o => { Preprocesor.stepBackward(); },
                o => Preprocesor.canStepBackward()
                );
            NextStage = new RelayCommand(
                o => { Preprocesor.stepForward(); },
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

            SequenceOne = Visibility.Collapsed;
            SequenceTwo = Visibility.Collapsed;
            stageTabDictionary = createStageTabDictionary();

        }

        private Dictionary<Stage, int> createStageTabDictionary()
        {
            var dictionary = new Dictionary<Stage, int>();
            dictionary[Stage.Original] = 0;
            dictionary[SkeletoniserStage.Equalised] = 1;
            dictionary[SkeletoniserStage.Tresholded] = 2;
            dictionary[Stage.Final] = 3;

            return dictionary;
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

        private void StageChanged(object sender, StageChangedEventArgs e)
        {
            //Console.WriteLine($"Stage changed from {e.OldStage} to {e.NewStage}");
            SelectedTab = stageToTabIndex(e.NewStage);
        }

        private int stageToTabIndex(Stage stage)
        {
            if (stageTabDictionary.ContainsKey(stage))
            {
                return stageTabDictionary[stage];
            }
            Console.Error.WriteLine("Tab index was not found for stage " + stage);
            if (stageTabDictionary.ContainsKey(Stage.Original)){
                return stageTabDictionary[Stage.Original];
            }
            Console.Error.WriteLine("Missing tab index for original stage");
            return 0;
        }
    }
}
