using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerFinder
{
    public partial class FingerprintAnalyzer
    {
        private Image fingerprintOriginal;
        private Image fingerpintSkeleton;

        public Image FingerprintOriginal
        {
            get { return fingerprintOriginal; }
            set
            {
                fingerprintOriginal = value;
                fingerpintSkeleton = createFingerprintSkeleton(value);

            }
        }
        public Image FingerprintSkeleton { get { return this.fingerpintSkeleton; } }

        private Image createFingerprintSkeleton(Image original)
        {
            Bitmap original_b = new Bitmap(original);
            Bitmap skeleton = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(skeleton);
            for(int y = 0; y < original.Height; y++)
            {
                for(int x = 0; x < original.Width; x++)
                {
                    Color c = original_b.GetPixel(original.Width - 1 - x, y);
                    skeleton.SetPixel(x, y, c);
                }
            }

            return skeleton;
        }


        internal Image getImage(int selectedIndex)
        {
            if(selectedIndex == 0)
            {
                return this.FingerprintOriginal;
            } else
            {
                return this.FingerprintSkeleton;
            }
        }
    }
}
