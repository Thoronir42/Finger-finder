using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer
{
    /* Classification */
    partial class Analyzer
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
