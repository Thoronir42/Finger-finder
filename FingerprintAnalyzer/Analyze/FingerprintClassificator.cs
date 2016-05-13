using FingerprintAnalyzer.Model;
using System;
using System.Drawing;

namespace FingerprintAnalyzer.Analyze
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
