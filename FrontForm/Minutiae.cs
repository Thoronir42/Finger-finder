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
        public PointF Position { get; set; } = new PointF();
        public MinutiaeType Type { get; set; } = MinutiaeType.Unspecified;
    }

    public enum MinutiaeType
    {
        Unspecified, 
        RidgeEnding, RidgeBifurcation, ShortRidge, Island, RidgeEnclosure, Spur, CrossoverOrBridge, Delta, Core
    }
}
