﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace FingerprintAnalyzer
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
            Type result;

            var xs = new XmlSerializer(typeof(Type));

            using (var reader = XmlReader.Create(fileName))
            {
                result = (Type)xs.Deserialize(reader);
            }

            return result;
        }
    }
}
