using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FingerprintAnalyzer.PreProcess.ImageManipulation;

namespace FingerprintAnalyzer.PreProcess.Sequences
{
    public class SequenceSlimify : ASequence
    {
        protected override bool isPreviewAvailable()
        {
            throw new NotImplementedException();
        }

        internal override Dictionary<Stage, AImageManipulator> getManipulators()
        {
            throw new NotImplementedException();
            Dictionary<Stage, AImageManipulator> manipulators = new Dictionary<Stage, AImageManipulator>();

            return manipulators;
        }

        internal override List<Stage> getStages()
        {
            throw new NotImplementedException();
            List<Stage> stages = new List<Stage> {
                SkeletoniserStage.Equalised,
                SkeletoniserStage.Tresholded
            };
            return stages;
        }
    }
}
