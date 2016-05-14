using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.PreProcess.ImageManipulation.ImageTools
{
    public class ImageDirection
    {
        public static ImageDirection get(Direction direction){ return directions[direction]; }

        private static Dictionary<Direction, ImageDirection> directions = initDirections();
        private static Dictionary<Direction, ImageDirection> initDirections()
        {
            var dict = new Dictionary<Direction, ImageDirection>();

            dict[Direction.Right]     = new ImageDirection { X = +1, Y = +0 };
            dict[Direction.TopRight]  = new ImageDirection { X = +1, Y = -1 };
            dict[Direction.Top]       = new ImageDirection { X = +0, Y = -1 };
            dict[Direction.TopLeft]   = new ImageDirection { X = -1, Y = -1 };
            dict[Direction.Left]      = new ImageDirection { X = -1, Y = +0 };
            dict[Direction.BottomLeft]= new ImageDirection { X = -1, Y = +1 };
            dict[Direction.Bottom]    = new ImageDirection { X = +0, Y = +1 };
            dict[Direction.BottomRight]= new ImageDirection { X = +1, Y = +1 };

            return dict;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }

    public enum Direction
    {
        Right = 0, TopRight = 1, Top = 2, TopLeft = 3,
        Left = 4, BottomLeft = 5, Bottom = 6, BottomRight = 7 
    }
}
