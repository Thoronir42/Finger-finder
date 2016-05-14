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
        public int[,] IntMap { get; private set; }

        private int width, height;
        public int Width { get { return width; } private set { width = value; } }
        public int Height { get { return height; } private set { height = value; } }

        private bool sign;
        public bool Sign { get { return sign; } private set { sign = value; } }

        public Pixel this[int x, int y]
        {
            get{
                if(x < 0 || x >= Width)
                {
                    throw new IndexOutOfRangeException();
                }
                if(y < 0 || y >= Height)
                {
                    throw new IndexOutOfRangeException();
                }
                return new Pixel(this, x, y);
            }
        }

        public Bitmap ToImage
        {
            get
            {
                Bitmap result = new Bitmap(Width, Height);
                for (int y = 1; y < Height - 1; y++)
                {
                    for (int x = 1; x < Width - 1; x++)
                    {
                        result.SetPixel(x, y, getColor(this[x, y]));
                    }
                }
                return result;
            }
        }


        public ImageMatrix(int[,] M)
        {
            constructorSetProperties(M, false);
        }

        public ImageMatrix(Bitmap image)
        {
            int[,] M = new int[image.Width, image.Height];

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    M[x, y] = getLuminance(image.GetPixel(x, y));
                }
            }
            constructorSetProperties(M, sign);
        }

        private void constructorSetProperties(int[,] M, bool sign)
        {
            Sign = sign;
            IntMap = M;
            Width = IntMap.GetLength(0);
            Height = IntMap.GetLength(1);
        }

        protected virtual int getLuminance(Color c)
        {
            return AImageManipulator.colorToLuminance(c);
        }
        protected virtual Color getColor(int c)
        {
            return Color.FromArgb(c, c, c);
        }
    }
}
