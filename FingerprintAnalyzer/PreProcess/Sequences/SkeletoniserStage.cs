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
            stageOriginal = new SkeletoniserStage("Původní snímek"),
            stageEqualised = new SkeletoniserStage("Ekvalizovaný snímek"),
            stageTresholded = new SkeletoniserStage("Naprahovaný snímek");

        public SkeletoniserStage(string label) : base(label) { }

        public static SkeletoniserStage Original { get { return stageOriginal; } }
        public static SkeletoniserStage Equalised { get { return stageEqualised; } }
        public static SkeletoniserStage Tresholded { get { return stageTresholded; } }
    }
}
