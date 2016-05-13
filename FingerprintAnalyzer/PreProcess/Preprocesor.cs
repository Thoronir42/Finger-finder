using FingerprintAnalyzer.Model;
using FingerprintAnalyzer.PreProcess.Sequences;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintAnalyzer.PreProcess
{
    public partial class Preprocesor : BaseModel
    {
        public void createNewFromImage(Image original)
        {
            CurrentStage = Stage.ChoosingSequence;
            Images[CurrentStage] = original;
        }

        public void loadAndCreateFrom(string fileName)
        {
            Image fingerprint = Image.FromFile(fileName);
            this.createNewFromImage(fingerprint);
        }
    }
}
