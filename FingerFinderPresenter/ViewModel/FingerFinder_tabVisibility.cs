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
        private int selectedTab = 0;
        public int SelectedTab {
            get { return selectedTab; }
            set
            {
                selectedTab = value;
                NotifyPropertyChanged();
            }
        }

        private Visibility[] visibilities = new Visibility[6];

        public Visibility VisibilityIntroduction { get { return visibilities[0]; } set { visibilities[0] = value; NotifyPropertyChanged(); } }

        public Visibility VisibilityPreprocess {
            get { return visibilities[1]; }
            set {
                visibilities[1] = value; NotifyPropertyChanged();
                NotifyPropertyChanged("VisibilitySequenceOne");
                NotifyPropertyChanged("VisibilitySequenceTwo");
            }
        }
        public Visibility VisibilityChooseSequence { get { return visibilities[5]; } set { visibilities[5] = value; NotifyPropertyChanged(); } }
        public Visibility VisibilitySequenceOne { get { return getSequenceVisibility(visibilities[2]); } set { visibilities[2] = value; NotifyPropertyChanged(); } }
        public Visibility VisibilitySequenceTwo { get { return getSequenceVisibility(visibilities[3]); } set { visibilities[3] = value; NotifyPropertyChanged(); } }

        public Visibility VisibilityAnalyze { get { return visibilities[4]; } set { visibilities[4] = value; NotifyPropertyChanged(); } }

        private Dictionary<Stage, int> stageTabDictionary;

        private void InitializeTabVisibility()
        {
            updateTabVisibilities(Stage.JustOpened);
            updateSequenceVisibilities(null);

            stageTabDictionary = createStageTabDictionary();
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

        private void updateSequenceVisibilities(ASequence selectedSequence)
        {
            Type selectedType = selectedSequence == null ? null : selectedSequence.GetType();
            VisibilitySequenceOne = boolToVisible(typeof(SequenceSkeletisation).Equals(selectedType));
            VisibilitySequenceTwo = boolToVisible(typeof(SequenceSlimify).Equals(selectedType));
        }

        private void updateTabVisibilities(Stage currentStage)
        {
            VisibilityIntroduction = boolToVisible(currentStage.Equals(Stage.JustOpened));
            VisibilityChooseSequence = boolToVisible(currentStage.Equals(Stage.ChoosingSequence));
            VisibilityPreprocess = boolToVisible(currentStage.IsPreprocessStage);
            VisibilityAnalyze = boolToVisible(currentStage.Equals(Stage.Final));
        }

        private static Visibility boolToVisible(bool visible)
        {
            return visible ? Visibility.Visible : Visibility.Collapsed;
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
