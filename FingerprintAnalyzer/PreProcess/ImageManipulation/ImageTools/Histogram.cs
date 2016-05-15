using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.PreProcess.ImageManipulation.ImageTools
{
    public class Histogram
    {
        private int[] luminancyLevels = new int[256];
        public int this[int l] {
            get { return luminancyLevels[l]; }
            set {
                luminancyLevels[l] = value;
                if (Max < l)
                {
                    Max = l;
                }
                if(Min > l)
                {
                    Min = l;
                }   
            }
        }

        public int Max { get; set; } = 0;
        public int Min { get; set; } = 255;

        public int Range { get { return Max - Min; } }


        public int Distribution(int l)
        {
            int sum = 0;
            for (int i = 0; i < l; i++)
            {
                sum += luminancyLevels[i];
            }
            return sum;
        }

        public static explicit operator int[](Histogram h)
        {
            return h.luminancyLevels;
        }

        public static explicit operator Histogram(int[] hist)
        {
            if(hist.Length != 256)
            {
                throw new ArgumentException("Luminancy array must have 256 values");
            }
            Histogram h = new Histogram { luminancyLevels = hist };

            return h;
        }
    }
}
