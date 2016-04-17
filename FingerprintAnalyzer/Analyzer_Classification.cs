using FingerprintAnalyzer.Model;
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
}
