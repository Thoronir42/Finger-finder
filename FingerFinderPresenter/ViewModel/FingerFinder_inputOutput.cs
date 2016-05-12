using FingerprintAnalyzer.Analyze;
using FingerprintAnalyzer.Model;
using FingerprintAnalyzer.PreProcess.Sequences;
using Microsoft.Win32;
using System;

namespace FingerFinderPresenter.ViewModel
{
    partial class FingerFinder : BaseModel
    {

        public RelayCommand CmdImport { get; set; }
        public RelayCommand CmdLoad { get; set; }
        public RelayCommand CmdSave { get; set; }

        private void InitializeCommands()
        {

            CmdImport = new RelayCommand(
                o => { ImportFingerprint(); },
                o => analyzer != null
                );
            CmdLoad = new RelayCommand(
                o => { LoadFingerprintData(); },
                o => false // TODO implement
                );
            CmdSave = new RelayCommand(
                o => { SaveFingerprintData(); },
                o => analyzer != null && analyzer.CurrentStage == Stage.Final
                );
        }

        private void previewChanges()
        {
            if (Analyzer.CurrentStage.Equals(SkeletoniserStage.Equalised))
            {
                Analyzer.peakForward();
                drawFingerprint(SkeletoniserStage.Tresholded);
            }
        }

        private bool ImportFingerprint()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.tif, *.png) | *.jpg; *.jpeg; *.tif; *.png";
            if (openFileDialog.ShowDialog() != true)
            {
                return false;
            }
            Console.WriteLine("Opened file: " + openFileDialog.FileName);

            try
            { 
                this.Analyzer.loadAndCreateFrom(openFileDialog.FileName);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Image loading failed: " + ex.ToString());
            }

            return true;
        }

        private bool SaveFingerprintData()
        {
            SaveFileDialog saver = new SaveFileDialog();
            saver.Filter = "Otisk prstu (*.fpr) | *.fpr;";
            if (saver.ShowDialog() != true)
            {
                return false;
            }
            Analyzer.saveToFile(saver.FileName);
            return true;
        }

        private bool LoadFingerprintData()
        {
            return false;
        }

    }

}
