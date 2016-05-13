using FingerprintAnalyzer.PreProcess.ImageManipulation;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FingerprintAnalyzer.PreProcess.Sequences
{
    abstract class ASequence
    {
        private readonly List<Stage> stages;
        private int iCurrentStage;

        public Stage CurrentStage {
            get { return this.stages[iCurrentStage]; }
            set
            {
                if (stages.Contains(value))
                {
                    iCurrentStage = stages.IndexOf(value);
                }
                throw new ArgumentException("Provided stage does not belong to current pool of available stages");
            }
        }

        private Dictionary<Stage, AImageManipulator> manipulators;


        internal abstract List<Stage> getStages();
        internal abstract Dictionary<Stage, AImageManipulator> getManipulators();

        public ASequence()
        {
            this.stages = this.getStages();
        }

        public Stage StepBackward()
        {
            iCurrentStage -= 1;
            return CurrentStage;
            
        }
        public Stage StepForward(Image source, out Image destination, bool preview = false)
        {
            AImageManipulator manipulator = this.getManipulator(CurrentStage);
            destination = manipulator.transform(source);
            if (!preview) {
                iCurrentStage++;
            }
            return CurrentStage;
        }

        public bool CanStepBackward()
        {
            return false;
        }

        public bool CanStepForward()
        {
            return false;
        }

        internal AImageManipulator getManipulator(Stage currentStage)
        {
            if (manipulators.ContainsKey(currentStage))
            {
                return manipulators[currentStage];
            }
            return null;
        }
    }
}
