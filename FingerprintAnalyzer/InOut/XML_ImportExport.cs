﻿using FingerprintAnalyzer.Model;
using System.Xml;
using System.Xml.Serialization;

namespace FingerprintAnalyzer.InOut
{
    /// <summary>
    /// Generic data importer/exporter
    /// </summary>
    /// <typeparam name="Type">Specification of type to be imported/exported</typeparam>
    public class XML_ImportExport<Type>
    {

        public void Save(Type typeInstance, string fileName)
        {
            var xs = new XmlSerializer(typeof(Type));

            using (var writer = XmlWriter.Create(fileName, new XmlWriterSettings() { Indent = true }))
            {
                xs.Serialize(writer, typeInstance);
            }
        }

        public Type Load(string fileName)
        {
            var xs = new XmlSerializer(typeof(Type));

            using (var reader = XmlReader.Create(fileName))
            {
                return (Type)xs.Deserialize(reader);
            }
        }
    }
}
