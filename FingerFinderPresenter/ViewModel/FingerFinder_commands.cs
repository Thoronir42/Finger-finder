using FingerprintAnalyzer;
using FingerprintAnalyzer.Analyze;
using FingerprintAnalyzer.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FingerFinderPresenter.ViewModel
{
    partial class FingerFinder : BaseModel
    {
        public RelayCommand PreviousStage { get; set; }
        public RelayCommand NextStage { get; set; }

        public RelayCommand CmdImport { get; set; }
        public RelayCommand CmdSave { get; set; }

        private void InitializeCommands()
        {
            PreviousStage = new RelayCommand(
                o => { previousStage(); },
                o => analyzer.CurrentStage > Analyzer.FirstStage
                );
            NextStage = new RelayCommand(
                o => { nextStage(); },
                o => analyzer.CurrentStage != Analyzer.Stages.Standby && analyzer.CurrentStage < Analyzer.LastStage
                );
            CmdImport = new RelayCommand(
                o => { ImportFingerprint(); },
                o => analyzer != null
                );
            CmdSave = new RelayCommand(
                o => { SaveFingerprintData(); },
                o => analyzer != null && analyzer.CurrentStage == Analyzer.Stages.Finalised
                );
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
            Analyzer.mockAnalyzeAndClassify();

            SaveFileDialog saver = new SaveFileDialog();
            saver.Filter = "Otisk prstu (*.fpr) | *.fpr;";
            if (saver.ShowDialog() != true)
            {
                return false;
            }
            Analyzer.saveToFile(saver.FileName);
            return true;
        }
    }

}
