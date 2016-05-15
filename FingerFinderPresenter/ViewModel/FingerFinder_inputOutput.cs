using FingerprintAnalyzer.Analyze;
using FingerprintAnalyzer.Model;
using FingerprintAnalyzer.InOut;
using FingerprintAnalyzer.PreProcess.Sequences;
using Microsoft.Win32;
using System;
using System.Drawing;

namespace FingerFinderPresenter.ViewModel
{
    partial class FingerFinder : BaseModel
    {

        public RelayCommand CmdImport { get; set; }
        public RelayCommand CmdLoad { get; set; }
        public RelayCommand CmdSave { get; set; }

        public FingerprintIO IO { get; private set; } = new FingerprintIO();

        private string IOFilter { get; } = String.Format("Otisk prstu (*.{0}) | *.{0};", FingerprintIO.FILE_EXTENSION);

        private void InitializeCommands()
        {

            CmdImport = new RelayCommand(
                o => { ImportFingerprint(); }
                );
            CmdLoad = new RelayCommand( o => { LoadFingerprintData(); } );
            CmdSave = new RelayCommand(
                o => { SaveFingerprintData(); },
                o => Preprocesor.CurrentStage == Stage.Final
                );
        }

        private bool ImportFingerprint()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Obrázek (*.jpg, *.jpeg, *.tif, *.png) | *.jpg; *.jpeg; *.tif; *.png";
            if (openFileDialog.ShowDialog() != true)
            {
                return false;
            }
            Console.WriteLine("Importing from file: " + openFileDialog.FileName);

            try
            {
                Image image = Image.FromFile(openFileDialog.FileName);
                Preprocesor.createNewFromImage(image);
                Console.WriteLine("Import successfull: " + openFileDialog.FileName);
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
            
            saver.Filter = IOFilter;
            if (saver.ShowDialog() != true)
            {
                return false;
            }
            return IO.save(saver.FileName, Analyzer.FingerprintData, Analyzer.FingerprintImage);
        }

        private bool LoadFingerprintData()
        {
            OpenFileDialog opener = new OpenFileDialog();
            opener.Filter = IOFilter;
            if(opener.ShowDialog() != true)
            {
                return false;
            }

            Image img;
            FingerprintData data;

            if (!IO.load(opener.FileName, out img, out data))
            {
                return false;
            }

            Analyzer.SetFingerprint(img, data);
            Preprocesor.SelectedSequence = new SequenceLoaded();
            CurrentlyRenderedImage = img;

            return true;
        }

    }

}
