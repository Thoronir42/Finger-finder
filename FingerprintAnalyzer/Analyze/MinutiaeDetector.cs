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
                PointF point = new PointF((float)randVal.NextDouble(), (float)randVal.NextDouble());
                Minutia minutia = new Minutia { Type = types[i], Position = point };
                minutiae.Add(minutia);
            }
            return minutiae;
        }

    }
}
