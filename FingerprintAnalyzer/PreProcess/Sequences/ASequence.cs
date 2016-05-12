using FingerprintAnalyzer.PreProcess.ImageManipulation;
using System.Collections.Generic;
using System.Drawing;

namespace FingerprintAnalyzer.PreProcess.Sequences
{
    abstract class ASequence
    {
        private readonly List<Stage> stages;
        private int currentStage;

        public ASequence()
        {
            
        }

        internal abstract List<AImageManipulator> getManipulators();

        public void StepBackward()
        {
            currentStage -= 1;
            
        }
        public Image StepForward(Image source, bool preview = false)
        {
            return this.stages[currentStage].transform(source);
        }

        public bool CanStepBackward()
        {
            return false;
        }
    
        public bool CanStepForward()
        {
            return false;
        }
    }
}
