using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.Analyze
{
    public enum AnalyzerStages
    {
        Original = 0,
        Equalized = 1,
        Tresholded = 2,
        Skeletonized = 3,
    }
}
