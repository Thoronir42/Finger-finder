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

        public int SelectedTab { get { return selectedTab; } set { selectedTab = value; NotifyPropertyChanged(); selectedIndexChanged(value); } }


        private Visibility[] visibilities = new Visibility[5];

        public Visibility VisibilityIntroduction { get { return visibilities[0]; } set { visibilities[0] = value; NotifyPropertyChanged(); } }

        public Visibility VisibilityPreprocess {
            get { return visibilities[1]; }
            set {
                visibilities[1] = value; NotifyPropertyChanged();
                NotifyPropertyChanged("VisibilitySequenceOne");
                NotifyPropertyChanged("VisibilitySequenceTwo");
            }
        }
        public Visibility VisibilitySequenceOne { get { return getSequenceVisibility(visibilities[2]); } set { visibilities[2] = value; NotifyPropertyChanged(); } }
        public Visibility VisibilitySequenceTwo { get { return getSequenceVisibility(visibilities[3]); } set { visibilities[3] = value; NotifyPropertyChanged(); } }

        public Visibility VisibilityAnalyze { get { return visibilities[4]; } set { visibilities[4] = value; NotifyPropertyChanged(); } }

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

            VisibilityIntroduction = Visibility.Visible;

            VisibilityPreprocess = Visibility.Collapsed;
            VisibilitySequenceOne = Visibility.Collapsed;
            VisibilitySequenceTwo = Visibility.Collapsed;

            VisibilityAnalyze = Visibility.Collapsed;

            stageTabDictionary = createStageTabDictionary();

        }

        private void previewChanges()
        {
            if (Preprocesor.CurrentStage.Equals(SkeletoniserStage.Equalised))
            {
                CurrentlyRenderedImage = Preprocesor.peekForward();
            }
        }

        private Dictionary<Stage, int> createStageTabDictionary()
        {
            var dictionary = new Dictionary<Stage, int>();
            dictionary[Stage.JustOpened] = 0;
            dictionary[Stage.ChoosingSequence] = 1;

            dictionary[SkeletoniserStage.Original] = 2;
            dictionary[SkeletoniserStage.Equalised] = 3;
            dictionary[SkeletoniserStage.Tresholded] = 4;
            dictionary[Stage.Final] = 8;

            return dictionary;
        }

        private void ChooseSequence(int sequence)
        {
            VisibilitySequenceOne = Visibility.Collapsed;
            VisibilitySequenceTwo = Visibility.Collapsed;

            ASequence select;
            if(sequence == 1)
            {
                VisibilitySequenceOne = Visibility.Visible;
                select = new SequenceSkeletisation();
            } else
            {
                VisibilitySequenceTwo = Visibility.Visible;
                select = new SequenceSlimify();
            }
            Preprocesor.SelectedSequence = select;

        }

        private void StageChanged(object sender, StageChangedEventArgs e)
        {
            //Console.WriteLine($"Stage changed from {e.OldStage} to {e.NewStage}");
            VisibilityIntroduction = Visibility.Collapsed;
            VisibilityPreprocess = Visibility.Collapsed;
            VisibilityAnalyze = Visibility.Collapsed;

            if (e.NewStage == Stage.Final)
            {
                VisibilityAnalyze = Visibility.Visible;
            }
            else
            {
                VisibilityPreprocess = Visibility.Visible;
            }
            SelectedTab = stageToTabIndex(e.NewStage);
        }

        private Visibility getSequenceVisibility(Visibility individual)
        {
            if(VisibilityPreprocess != Visibility.Visible)
            {
                return Visibility.Collapsed;
            }
            return individual;
        }

        private int stageToTabIndex(Stage stage)
        {
            if (stageTabDictionary.ContainsKey(stage))
            {
                return stageTabDictionary[stage];
            }
            Console.Error.WriteLine("Tab index was not found for stage " + stage);
            if (stageTabDictionary.ContainsKey(Stage.ChoosingSequence)){ // TODO: add error tab
                return stageTabDictionary[Stage.ChoosingSequence];
            }
            Console.Error.WriteLine("Missing tab index for original stage");
            return 0;
        }
    }
}
