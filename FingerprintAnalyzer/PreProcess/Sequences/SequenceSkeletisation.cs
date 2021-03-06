﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FingerprintAnalyzer.PreProcess.ImageManipulation;

namespace FingerprintAnalyzer.PreProcess.Sequences
{
    public class SequenceSkeletisation : ASequence
    {
        protected override bool isPreviewAvailable()
        {
            return CurrentStage == SkeletoniserStage.Equalised;
        }

        internal override Dictionary<Stage, AImageManipulator> getManipulators()
        {
            Dictionary<Stage, AImageManipulator> manipulators = new Dictionary<Stage, AImageManipulator>();

            manipulators[SkeletoniserStage.Original] = ImageEqualizer.Instance;
            manipulators[SkeletoniserStage.Equalised] = ImageTresholder.Instance;
            manipulators[SkeletoniserStage.Tresholded] = ImageSkeletonizer.Instance;

            return manipulators;
        }

        internal override List<Stage> getStages()
        {
            List<Stage> stages = new List<Stage> {
                SkeletoniserStage.Original,
                SkeletoniserStage.Equalised,
                SkeletoniserStage.Tresholded
            };
            return stages;
        }
    }
}
