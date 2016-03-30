using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerFinder
{
    public class Minutiae
    {
        public PointF Position { get; set; }
        public MinutiaeType Type { get; set; }

    }

    public enum MinutiaeType
    {
        RidgeEnding, RidgeBifurcation, ShortRidge, Island, RidgeEnclosure, Spur, CrossoverOrBridge, Delta, Core
    }
}
