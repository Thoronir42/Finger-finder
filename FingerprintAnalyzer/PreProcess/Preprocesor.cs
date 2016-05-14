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

            SelectedSequence = null;
            CurrentStage = Stage.ChoosingSequence;
        }

        /// <summary>
        /// Returns image corresponding to requested stageNumber or original if stage number wasn't recognised
        /// </summary>
        /// <param name="stage">Stage number specifying requested image</param>
        /// <returns>Corresponding image</returns>
        public Image getImageFor(Stage stage)
        {
            if (Images.ContainsKey(stage))
            {
                return Images[stage];
            }
            if (Images.ContainsKey(Stage.ChoosingSequence))
            {
                return Images[Stage.ChoosingSequence];
            }
            return null;
        }
        public Image getImageFor(int index)
        {
            Stage stage = getStageBySelectedIndex(index);
            return getImageFor(stage);
        }
    }
}
