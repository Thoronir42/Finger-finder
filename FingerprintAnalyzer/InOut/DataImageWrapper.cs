using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.InOut
{
    public class DataImageWrapper<Type>
    {
        public string ImageFilename { get; set; }

        public Type Item { get; set; }

    }
}
