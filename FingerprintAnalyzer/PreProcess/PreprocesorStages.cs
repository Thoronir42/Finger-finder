using FingerprintAnalyzer.Model;
using FingerprintAnalyzer.PreProcess.Sequences;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.PreProcess
{
    //stages
    partial class Preprocesor
    {
        private ASequence selectedSequence;
        public ASequence SelectedSequence {
            get { return selectedSequence; }
            set
            {
                selectedSequence = value;
                if(selectedSequence != null) {
                    CurrentStage = selectedSequence.CurrentStage;
                }
                
            }
        }

        public Dictionary<Stage, Image> Images { get; private set; } = new Dictionary<Stage, Image>();

        public Stage currentStage = Stage.JustOpened;
        public Stage CurrentStage
        {
            get { return currentStage; }
            set
            {
                var oldStage = currentStage;
                currentStage = value;

                stageChanged(oldStage, value);
                NotifyPropertyChanged();
                NotifyPropertyChanged("CurrentImage");
            }
        }
        public event StageChangedEventHandler StageChanged;



        public bool PreviewAvailable { get { return SelectedSequence != null && SelectedSequence.PreviewAvailable; } }

        public Image CurrentImage { get { return this.getImageFor(CurrentStage); } }
        
        public void stepBackward()
        {
            CurrentStage = SelectedSequence.StepBackward();
        }

        public Image stepForward(dynamic parameters = null)
        {
            Image newImage;
            Stage newStage = SelectedSequence.StepForward(CurrentImage, out newImage, parameters);

            Images[newStage] = newImage;
            CurrentStage = newStage;

            return newImage;
        }

        public Image peekForward(dynamic parameters = null)
        {
            Image newImage;
            SelectedSequence.StepForward(CurrentImage, out newImage, true, parameters);
            return newImage;
        }

        public bool canStepForward()
        {
            return SelectedSequence != null && SelectedSequence.CanStepForward();
        }

        public bool canStepBackward()
        {
            return SelectedSequence != null && SelectedSequence.CanStepBackward();
        }

        public Stage getStageBySelectedIndex(int index)
        {
            if(SelectedSequence == null)
            {
                return Stage.ChoosingSequence;
            }
            return this.SelectedSequence.getStage(index);
        }

        private void stageChanged(Stage oldValue, Stage newValue)
        {
            var args = new StageChangedEventArgs { OldStage = oldValue, NewStage = newValue };
            StageChanged?.Invoke(this, args);
        }
    }
}
