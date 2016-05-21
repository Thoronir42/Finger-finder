﻿using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace FingerprintAnalyzer.InOut
{
    /// <summary>
    /// Version wrapper which allows XML serialisation
    /// 
    /// Taken from http://stackoverflow.com/questions/2085866/system-version-not-serialized
    /// </summary>
    [Serializable]
    [XmlType("Version")]
    public class VersionXml
    {
        public VersionXml()
        {
            this.Version = null;
        }

        public VersionXml(Version Version)
        {
            this.Version = Version;
        }

        [XmlIgnore]
        public Version Version { get; set; }

        [XmlText]
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public string Value
        {
            get { return this.Version == null ? string.Empty : this.Version.ToString(); }
            set
            {
                Version temp;
                Version.TryParse(value, out temp);
                this.Version = temp;
            }
        }

        public static implicit operator Version(VersionXml VersionXml)
        {
            return VersionXml.Version;
        }

        public static implicit operator VersionXml(Version Version)
        {
            return new VersionXml(Version);
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
