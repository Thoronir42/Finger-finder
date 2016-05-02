﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace FingerprintAnalyzer.Model
{
    /// <summary>
    /// Fingerprint data container
    /// </summary>
    public class FingerprintData : BaseModel, IDisposable
    {
        private DateTime dateSaved = DateTime.Now;
        private string name = "John Doe";
        private ObservableCollection<Minutia> minutiae = new ObservableCollection<Minutia>();
        private FingerprintCategory category = FingerprintCategory.Undefined;

        [XmlElement("SavedOn")]
        public DateTime DateSaved
        {
            get { return dateSaved; }
            set {
                dateSaved = value;
                NotifyPropertyChanged();
            }
        }

        [XmlElement("Name")]
        public string Name
        {
            get { return name; }
            set {
                name = value;
                NotifyPropertyChanged();
            }
        }

        [XmlElement("Minutiae")]
        public ObservableCollection<Minutia> Minutiae
        {
            get { return minutiae; }
            set
            {
                minutiae = value;
                NotifyPropertyChanged();
            }
        }

        [XmlElement("Category")]
        public FingerprintCategory Category
        {
            get { return category; }
            set
            {
                category = value;
                NotifyPropertyChanged();
            }
        }

        public FingerprintData()
        {
            minutiae.CollectionChanged += this.minutiaeCollectionChanged;
        }

        private void minutiaeCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.NotifyPropertyChanged("Minutiae");
        }

        public void Dispose()
        {
            minutiae.CollectionChanged -= this.minutiaeCollectionChanged;
        }

        


    }
}
