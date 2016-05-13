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
        private ASequence SelectedSequence { get; set; }

        public Stage currentStage;
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

        public bool PreviewAvailable { get { return false; } }

        public Image CurrentImage { get { return this.getImageFor(CurrentStage); } }

        public Dictionary<Stage, Image> Images { get; private set; }

        public void stepBackward()
        {
            CurrentStage = SelectedSequence.StepBackward();
        }

        public Image stepForward()
        {
            Image newImage;
            Stage newStage = SelectedSequence.StepForward(CurrentImage, out newImage);

            Images[newStage] = newImage;
            CurrentStage = newStage;

            return newImage;
        }

        public Image peekForward()
        {
            Image newImage;
            SelectedSequence.StepForward(CurrentImage, out newImage, true);
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

        /// <summary>
        /// Returns image corresponding to requested stageNumber or original if stage number wasn't recognised
        /// </summary>
        /// <param name="stage">Stage number specifying requested image</param>
        /// <returns>Corresponding image</returns>
        public Image getImageFor(Stage stage)
        {
            if (Images.ContainsKey(stage))
            {
                return Images[stage];
            }
            if (Images.ContainsKey(Stage.Original))
            {
                return Images[Stage.Original];
            }
            return null;
        }
        public Image getImageFor(int index)
        {
            Stage stage = getStageBySelectedIndex(index);
            return getImageFor(stage);
        }


        public Stage getStageBySelectedIndex(int index)
        {
            return this.SelectedSequence.getStage(index);
        }

        private void stageChanged(Stage oldValue, Stage newValue)
        {
            var args = new StageChangedEventArgs { OldStage = oldValue, NewStage = newValue };
            StageChanged?.Invoke(this, args);
        }
    }
}
