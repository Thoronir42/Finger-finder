using FingerprintAnalyzer.PreProcess.Sequences;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.Analyze
{
    partial class Analyzer
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

        public void stepForward()
        {
            return SelectedSequence.CanStepForward();
        }

        public void peakForward()
        {
            throw new NotImplementedException();
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
    }
}
