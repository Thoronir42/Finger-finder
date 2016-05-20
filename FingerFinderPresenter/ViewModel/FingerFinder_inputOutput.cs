using FingerprintAnalyzer.Analyze;
using FingerprintAnalyzer.Model;
using FingerprintAnalyzer.InOut;
using FingerprintAnalyzer.PreProcess.Sequences;
using Microsoft.Win32;
using System;
using System.Drawing;
using FingerFinderPresenter.Toolkits;

namespace FingerFinderPresenter.ViewModel
{
    partial class FingerFinder : BaseModel
    {
        public const int TARGET_IMAGE_WIDTH = 300;
        public const int TARGET_IMAGE_HEIGHT = 300;


        public RelayCommand CmdImport { get; set; }
        public RelayCommand CmdLoad { get; set; }
        public RelayCommand CmdSave { get; set; }

        public FingerprintIO IO { get; private set; } = new FingerprintIO();

        private string IOFilter { get; } = String.Format("Otisk prstu (*.{0}) | *.{0};", FingerprintIO.FILE_EXTENSION);

        private void InitializeCommands()
        {

            CmdImport = new RelayCommand( o => { ImportFingerprint(); } );
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
                image = ImageTools.resize(image, TARGET_IMAGE_WIDTH, TARGET_IMAGE_HEIGHT);

                Preprocesor.createNewFromImage(image);
                Analyzer.Clear();
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

            Image image;
            FingerprintData data;

            if (!IO.load(opener.FileName, out image, out data))
            {
                return false;
            }

            image = ImageTools.resize(image, TARGET_IMAGE_WIDTH, TARGET_IMAGE_HEIGHT);

            Analyzer.SetFingerprint(image, data);
            Preprocesor.Images[Stage.Final] = image;
            Preprocesor.SelectedSequence = new SequenceLoaded();

            return true;
        }

    }

}
