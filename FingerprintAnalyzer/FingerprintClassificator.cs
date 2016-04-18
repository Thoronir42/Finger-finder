using FingerprintAnalyzer.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer
{
    /// <summary>
    /// Analyzes fingerprint image
    /// </summary>
    class FingerprintClassificator
    {
        /// <summary>
        /// Returns apropriate fingerprint category based on provided image
        /// TODO: actual functionality
        /// </summary>
        /// <param name="skeleton">Image to be categorised</param>
        /// <returns>Corresponding fingerprint category</returns>
        public FingerprintCategory classificate(Image skeleton)
        {
            return FingerprintCategory.Undefined;
        }

    }
}
