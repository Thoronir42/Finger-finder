using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerFinder
{
    /* Minutiae */
    partial class FingerprintAnalyzer
    {
        public FingerprintCategory classificate()
        {
            return FingerprintCategory.ArchPlain;
        }

    }

    public enum FingerprintCategory
    {
        ArchPlain, ArchTented, LoopRadial, LoopUlnar, WhorlPlain, WhorlCentralPocket, WhorlDoubleLoop, WhorlAccidental
    }
}
