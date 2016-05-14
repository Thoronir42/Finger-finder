using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.PreProcess.ImageManipulation.ImageTools
{
    public partial class ImageMatrix
    {
        public class Pixel : IComparable<Pixel>
        {
            public ImageMatrix Matrix { get; private set; }
            public int X { get; private set; }
            public int Y { get; private set; }

            public int Luminance {
                get { return Matrix.IntMap[X, Y]; }
                set { Matrix.IntMap[X, Y] = value; }
            }

            public Pixel this[Direction direction]
            {
                get
                {
                    var imgDir = ImageDirection.get(direction);
                    int newX = X + imgDir.X;
                    int newY = Y + imgDir.Y;

                    return Matrix[newX, newY];
                }
            }

            public Pixel(ImageMatrix matrix, int x, int y)
            {
                Matrix = matrix;
                X = x;
                Y = y;
            }

            public int CompareTo(Pixel other)
            {
                if(other == null)
                {
                    return 1;
                }
                return Luminance == other.Luminance ? 0 : (Luminance > other.Luminance ? 1 : -1);
            }

            public static bool operator >(Pixel p1, Pixel p2)
            {
                return p1.CompareTo(p2) > 0;
            }

            public static bool operator <(Pixel p1, Pixel p2)
            {
                return p2 > p1;
            }

            public static bool operator >= (Pixel p1, Pixel p2)
            {
                return p1.CompareTo(p2) >= 0;
            }

            public static bool operator <=(Pixel p1, Pixel p2)
            {
                return p2 >= p1;
            }

            public static implicit operator int(Pixel p)
            {
                return p.Luminance;
            }

            public static explicit operator Color(Pixel p) {
                return Color.FromArgb(p, p, p);
            }
        }
    }
}
