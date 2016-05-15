using System.Collections.Generic;
using FingerprintAnalyzer.PreProcess.ImageManipulation;

namespace FingerprintAnalyzer.PreProcess.Sequences
{
    public class SequenceLoaded : ASequence
    {
        protected override bool isPreviewAvailable()
        {
            return false;
        }

        internal override Dictionary<Stage, AImageManipulator> getManipulators()
        {
            return new Dictionary<Stage, AImageManipulator>();
        }

        internal override List<Stage> getStages()
        {
            return new List<Stage>();
        }
    }
}
