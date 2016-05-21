using FingerprintAnalyzer.Model;
using System.Drawing;
using System;
using System.Drawing.Imaging;
using System.Windows;

namespace FingerprintAnalyzer.InOut
{
    public class FingerprintIO
    {
        public const string FILE_EXTENSION = "fpr";
        private XML_ImportExport<FingerprintWrapper> XML { get; } = new XML_ImportExport<FingerprintWrapper>();


        /// <summary>
        /// Loads fingerprint datafrom file
        /// TODO: specify which image (if any) will be saved alongside fingerprint data
        /// </summary>
        /// <param name="filePath">Location of file containing fingerprint data</param>
        /// <returns>Succesfullness of operation</returns>
        public bool load(string filePath, out Image destination, out FingerprintData data, out Version version)
        {
            try
            {
                var dataWrapper = XML.Load(filePath);
                data = dataWrapper.Item;
                string imageFilepath = makeImageFilepath(filePath, dataWrapper.ImageFilename);
                destination = Image.FromFile(imageFilepath);
                version = dataWrapper.Version;
                
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Loading failed: " + ex);
                MessageBox.Show("Nastala chyba při načítání souboru otisku prstu.", "Chyba načítání", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                data = null;
                destination = null;
                version = null;
                return false;
            }
        }

        private string makeImageFilepath(string filepath, string imageFilename)
        {
            var pathParts = filepath.Split('\\');
            pathParts[pathParts.Length - 1] = imageFilename;

            return String.Join("\\", pathParts);
        }

        /// <summary>
        /// Saves fingerprint data to file
        /// TODO: specify which image (if any) will be saved alongside fingerprint data
        /// </summary>
        /// <param name="filename">Desired destination for fingerprint data file</param>
        /// <returns>Succesfullness of operation</returns>
        public bool save(string filename, FingerprintData data, Image image, Version version = null)
        {
            try
            {
                string imagePath = saveImage(filename, image);
                var wrapper = new FingerprintWrapper { Item = data, ImageFilename = imagePath, Version = version };

                this.XML.Save(wrapper, filename);
                return true;
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine("Save error: " + ex);
                return false;
            }
        }

        private string saveImage(string filename, Image image)
        {
            string imagePath = replacePathFileToImage(filename);

            image.Save(imagePath, ImageFormat.Png);

            var pathParts = imagePath.Split('\\');

            return pathParts[pathParts.Length - 1];
        }

        private string replacePathFileToImage(string filename) {
            string[] pathParts = filename.Split('.');
            if (pathParts.Length < 2)
            {
                throw new FormatException("File name didn't contain extension");
            }
            pathParts[pathParts.Length - 1] = "png";

            return String.Join(".", pathParts);
        }
    }
}
