using FingerprintAnalyzer.Model;
using FingerprintAnalyzer.PreProcess.Sequences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerFinderPresenter.ViewModel
{
    partial class FingerFinder
    {
        public const int MINUTIA_COUNT_MAX = 40;

        public List<MinutiaType> MinutiaTypes
        {
            get { return MinutiaType.GetAllValues().ToList(); }
        }
        public List<FingerprintCategory> FingerprintCategories
        {
            get { return Enum.GetValues(typeof(FingerprintCategory)).Cast<FingerprintCategory>().ToList(); }
        }

        private Minutia selectedMinutia = new Minutia { Type = MinutiaType.Unspecified };
        public Minutia SelectedMinutia { get { return selectedMinutia; } set { selectedMinutia = value; NotifyPropertyChanged(); IsMinutiaSelected = value != null; } }

        private bool isMinutiaSelected = false;
        public bool IsMinutiaSelected
        {
            get { return isMinutiaSelected; }
            set
            {
                isMinutiaSelected = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand CmdAnalyze { get; set; }
        public RelayCommand CmdAddMinutia { get; set; }
        public RelayCommand CmdRemoveMinutia { get; set; }

        private void InitializeAnalyze()
        {
            CmdAnalyze = new RelayCommand(
                o => { Analyzer.analyzeFingerprint(); },
                o => Analyzer.CanAnalyze
                );

            CmdAddMinutia = new RelayCommand(
                o => { addMinutia(); },
                o => Analyzer.FingerprintData != null && Analyzer.FingerprintData.Minutiae.Count <= MINUTIA_COUNT_MAX
                );
            CmdRemoveMinutia = new RelayCommand(
                o => { removeMinutia(); },
                o => IsMinutiaSelected
                );
        }

        private void addMinutia()
        {
            Minutia m = new Minutia { };
            Analyzer.FingerprintData.Minutiae.Add(m);
            SelectedMinutia = m;
        }
        private void removeMinutia()
        {
            Analyzer.FingerprintData.Minutiae.Remove(SelectedMinutia);
            SelectedMinutia = null;
        }

    }
}
