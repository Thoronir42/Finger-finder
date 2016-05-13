using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.PreProcess.Sequences
{
    public class SkeletoniserStage : Stage
    {
        private static SkeletoniserStage
            stageOriginal = new SkeletoniserStage("Original"),
            stageEqualised = new SkeletoniserStage("Equalisation"),
            stageTresholded = new SkeletoniserStage("Tresholding");

        public SkeletoniserStage(string label) : base(label) { }

        public static SkeletoniserStage Original { get { return stageOriginal; } }
        public static SkeletoniserStage Equalised { get { return stageEqualised; } }
        public static SkeletoniserStage Tresholded { get { return stageTresholded; } }
    }
}
