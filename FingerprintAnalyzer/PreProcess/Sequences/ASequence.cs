using FingerprintAnalyzer.PreProcess.ImageManipulation;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FingerprintAnalyzer.PreProcess.Sequences
{
    abstract class ASequence
    {
        public List<Stage> Stages { get; }
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


        internal abstract List<Stage> getStages();
        internal abstract Dictionary<Stage, AImageManipulator> getManipulators();

        public ASequence()
        {
            this.Stages = this.getStages();
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
