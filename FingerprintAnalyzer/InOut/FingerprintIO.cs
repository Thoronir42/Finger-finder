using FingerprintAnalyzer.Model;
using System.Drawing;
using System;
using System.Drawing.Imaging;

namespace FingerprintAnalyzer.InOut
{
    public class FingerprintIO
    {
        public const string FILE_EXTENSION = "fpr";
        private XML_ImportExport<DataImageWrapper<FingerprintData>> XML { get; } = new XML_ImportExport<DataImageWrapper<FingerprintData>>();


        /// <summary>
        /// Loads fingerprint datafrom file
        /// TODO: specify which image (if any) will be saved alongside fingerprint data
        /// </summary>
        /// <param name="filePath">Location of file containing fingerprint data</param>
        /// <returns>Succesfullness of operation</returns>
        public bool load(string filePath, out Image destination, out FingerprintData data)
        {
            var dataWrapper = XML.Load(filePath);

            try
            {
                data = dataWrapper.Item;
                string imageFilepath = makeImageFilepath(filePath, dataWrapper.ImageFilename);
                destination = Image.FromFile(imageFilepath);

                Console.WriteLine("Loaded item: " + data);
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Loading failed: " + ex);
                data = null;
                destination = null;
                return false;
            }
        }

        private string makeImageFilepath(string filepath, string imageFilename)
        {
            var pathParts = filepath.Split('\\');
            pathParts[pathParts.Length - 1] = imageFilename;

            string imagePath = pathParts[0];
            for(int i = 1; i < pathParts.Length; i++)
            {
                imagePath += "\\" + pathParts[i];
            }

            return imagePath;
        }

        /// <summary>
        /// Saves fingerprint data to file
        /// TODO: specify which image (if any) will be saved alongside fingerprint data
        /// </summary>
        /// <param name="filename">Desired destination for fingerprint data file</param>
        /// <returns>Succesfullness of operation</returns>
        public bool save(string filename, FingerprintData data, Image image)
        {
            try
            {
                string imagePath = saveImage(filename, image);
                var wrapper = new DataImageWrapper<FingerprintData> { Item = data, ImageFilename = imagePath };

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
            string path = pathParts[0];
            for (int i = 1; i < pathParts.Length; i++)
            {
                path += "." + pathParts[i];
            }

            return path;
        }
    }
}
