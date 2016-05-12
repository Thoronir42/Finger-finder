using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FingerprintAnalyzer.PreProcess.ImageManipulation;

namespace FingerprintAnalyzer.PreProcess.Sequences
{
    class SequenceSkeletisation : ASequence
    {
        public SequenceSkeletisation()
        {
            
        }

        internal override List<AImageManipulator> getManipulators()
        {
            List<AImageManipulator> manipulators = new List<AImageManipulator>();
            manipulators.Add(new ImageEqualizer());
            manipulators.Add(new ImageTresholder());
            manipulators.Add(new ImageSkeletonizer());
            return manipulators;
        }
    }
}
