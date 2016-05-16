using System;
using System.Collections.Generic;
using System.Drawing;
using FingerprintAnalyzer.Model;

namespace FingerprintAnalyzer.Analyze
{
    class MinutiaeDetector
    {
        public List<Minutia> detectMinituae(Image fingerprintSkeleton)
        {
            var types = (MinutiaType[])Enum.GetValues(typeof(MinutiaType));
            List<Minutia> minutiae = new List<Minutia>();
            Random randVal = new Random(413);

            for (int i = 0; i < types.Length; i++)
            {
                Minutia minutia = new Minutia { Type = types[i], X = (float)randVal.NextDouble(), Y = (float)randVal.NextDouble() };
                minutiae.Add(minutia);
            }
            return minutiae;
        }

    }
}
