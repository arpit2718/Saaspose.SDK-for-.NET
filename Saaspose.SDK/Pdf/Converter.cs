using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Saaspose.Common;

namespace Saaspose.Pdf
{
    /// <summary>
    /// converts pages or document into different formats
    /// </summary>
    public class Converter
    {
        public Converter()
        {
            
        }
        
        public Converter(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// PDF document name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// convert a particular page to image
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="pageNumber"></param>
        public void GetImage(string outputPath, int pageNumber, ConvertImageFormat imageFormat, SaveLocation saveLocation, int imageHeight, int imageWidth)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString();
            strURI += "?format=" + imageFormat;
            strURI += "&width=" + imageWidth;
            strURI += "&height=" + imageHeight;

            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
            {
                Utils.CopyStream(responseStream, fileStream);
            }
            responseStream.Close();
 
        }

        /// <summary>
        /// convert a particular page to image with default size
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="pageNumber"></param>
        public void GetImage(string outputPath, int pageNumber, ConvertImageFormat imageFormat, SaveLocation saveLocation)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString();
            strURI += "?format=" + imageFormat;
           

            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
            {
                Utils.CopyStream(responseStream, fileStream);
            }
            responseStream.Close();

        }


        /// <summary>
        /// save the document into various formats
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="saveFormat"></param>
        public void Convert(string outputPath, SaveFormat saveFormat)
        {

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName;
            strURI += "?format=" + saveFormat;
            
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
            {
                Utils.CopyStream(responseStream, fileStream);
            }
            responseStream.Close();
 

        }

        /// <summary>
        /// Convert PDF to different file format without using storage
        /// </summary>
        /// <param name="outputFileName"></param>
        /// <param name="outputFormat"></param>
        public void ConvertLocalFile(string inputPath, string outputPath, SaveFormat outputFormat)
        {
            try
            {

                //build URI
                string strURI = Saaspose.Common.Product.BaseProductUri + "/pdf/convert?format=" + outputFormat;

                //sign URI
                string signedURI = Utils.Sign(strURI);

                FileStream stream = new FileStream(inputPath, FileMode.Open);

                //get response stream
                Stream responseStream = Utils.ProcessCommand(signedURI, "PUT", stream);

                using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
                {
                    Utils.CopyStream(responseStream, fileStream);
                }
                responseStream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Convert Pdf to different file format without using storage
        /// </summary>
        /// <param name="outputFileName"></param>
        /// <param name="outputFormat"></param>
        public Stream ConvertLocalFile(Stream inputStream, SaveFormat outputFormat)
        {
            try
            {
                //build URI
                string strURI = Saaspose.Common.Product.BaseProductUri + "/pdf/convert?format=" + outputFormat;

                //sign URI
                string signedURI = Utils.Sign(strURI);

                Stream fileStream = new MemoryStream();

                Utils.CopyStream(Utils.ProcessCommand(signedURI, "PUT", inputStream), fileStream);

                return fileStream;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
