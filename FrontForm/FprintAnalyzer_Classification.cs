using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerFinder
{
    /* Minutiae */
    partial class FprintAnalyzer
    {
        public FingerprintCategory classificate()
        {
            return FingerprintCategory.ArchPlain;
        }

    }

    enum FingerprintCategory
    {
        ArchPlain, ArchTented, LoopRadial, LoopUlnar, WhorlPlain, WhorlCentralPocket, WhorlDoubleLoop, WhorlAccidental
    }
}
