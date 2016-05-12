using FingerprintAnalyzer.Model;
using System.Drawing;
using FingerprintAnalyzer.PreProcess.Sequences;
using System;

namespace FingerprintAnalyzer.Analyze
{
    partial class Analyzer
    {
        private FingerprintXML XML { get; } = new FingerprintXML();

        public void createNewFromImage(Image original)
        {
            FingerprintData = new FingerprintData();
            CurrentStage = Stage.Original;
            Images[CurrentStage] = original;
        }

        public void loadAndCreateFrom(string fileName)
        {
            Image fingerprint = Image.FromFile(fileName);
            this.createNewFromImage(fingerprint);
        }

        /// <summary>
        /// Loads fingerprint datafrom file
        /// TODO: specify which image (if any) will be saved alongside fingerprint data
        /// </summary>
        /// <param name="filename">Location of file containing fingerprint data</param>
        /// <returns>Succesfullness of operation</returns>
        public bool loadFromFile(string filename)
        {
            this.XML.Load(filename);
            return true;
        }

        /// <summary>
        /// Saves fingerprint data to file
        /// TODO: specify which image (if any) will be saved alongside fingerprint data
        /// </summary>
        /// <param name="filename">Desired destination for fingerprint data file</param>
        /// <returns>Succesfullness of operation</returns>
        public bool saveToFile(string filename)
        {
            this.XML.Save(FingerprintData, filename);
            return true;
        }

        public Stage getStageBySelectedIndex(int newValue)
        {
            // TODO implement
            return Stage.Original;
        }
    }
}
