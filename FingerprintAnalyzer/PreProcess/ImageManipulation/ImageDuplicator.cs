using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.PreProcess.ImageManipulation
{
    /// <summary>
    /// Copies the image without transforming it. Serves for transfers between stages that do not require any transformations
    /// </summary>
    class ImageDuplicator : AImageManipulator
    {
        public static ImageDuplicator Instance { get; } = new ImageDuplicator();


        private ImageDuplicator() { }

        public override Image transform(Image original, dynamic parameters = null)
        {
            Bitmap origBitmap = new Bitmap(original);

            return origBitmap;
        }
    }
}
