using FingerprintAnalyzer.PreProcess.ImageManipulation;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FingerprintAnalyzer.PreProcess.Sequences
{
    public abstract class ASequence
    {
        public List<Stage> Stages { get; private set; }
        private int iCurrentStage;

        public Stage CurrentStage {
            get { return this.Stages[iCurrentStage]; }
            set
            {
                if (Stages.Contains(value))
                {
                    iCurrentStage = Stages.IndexOf(value);
                }
                throw new ArgumentException("Provided stage does not belong to current pool of available stages");
            }
        }

        private Dictionary<Stage, AImageManipulator> manipulators;


        public bool PreviewAvailable
        {
            get { return this.isPreviewAvailable(); }
        }

        public ASequence()
        {
            Stages = this.getStages();
            Stages.Add(Stage.Final);
            manipulators = getManipulators();
        }

        internal abstract List<Stage> getStages();
        internal abstract Dictionary<Stage, AImageManipulator> getManipulators();
        protected abstract bool isPreviewAvailable();


        public Stage StepBackward()
        {
            iCurrentStage -= 1;
            return CurrentStage;
            
        }
        public Stage StepForward(Image source, out Image destination, bool preview = false, dynamic parameters = null)
        {
            AImageManipulator manipulator = this.getManipulator(CurrentStage);
            destination = manipulator.transform(source, parameters);
            if (!preview) {
                iCurrentStage++;
            }
            return CurrentStage;
        }
        public Stage StepForward(Image source, out Image destination, dynamic parameters)
        {
            return StepForward(source, out destination, false, parameters);
        }

        public bool CanStepBackward()
        {
            return iCurrentStage > 0;
        }

        public bool CanStepForward()
        {
            return iCurrentStage < Stages.Count - 1;
        }

        internal AImageManipulator getManipulator(Stage currentStage)
        {
            if (manipulators.ContainsKey(currentStage))
            {
                return manipulators[currentStage];
            }
            return ImageDuplicator.Instance;
        }

        internal Stage getStage(int index)
        {
            if(index < 0 || index > Stages.Count)
            {
                throw new ArgumentOutOfRangeException($"For {GetType().Name}, stage index must be between 0 and {Stages.Count}, {index} given.");
            }
            return Stages[index];
        }
    }
}
