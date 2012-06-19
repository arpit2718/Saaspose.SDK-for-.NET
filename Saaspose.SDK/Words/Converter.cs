using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Storage;
using Saaspose.Common;
using System.IO;


namespace Saaspose.Words
{
    /// <summary>
    /// Class to convert file to different formats
    /// </summary>
    public class Converter
    {
        /// <summary>
        /// Converter Class Constructor
        /// </summary>
        public Converter()
        {

        }
        public Converter(string fileName)
        {

            //set default values
            FileName = fileName;

            saveformat = SaveFormat.Doc;
        }

        /// <summary>
        /// get or set Doc file name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// get or set the SaveFormat type
        /// </summary>
        public SaveFormat saveformat { get; set; }

        /// <summary>
        /// convert a document to SaveFormat
        /// </summary>
        /// <param name="output">the location of the output file</param>
        public void Convert(string output)
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Product.BaseProductUri + "/words/" + FileName;
                strURI += "?format=" + saveformat;

                //sign URI
                string signedURI = Utils.Sign(strURI);

                //get response stream
                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                using (Stream fileStream = System.IO.File.OpenWrite(output))
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
        /// convert a document to SaveFormat
        /// </summary>
        /// <param name="output">the location of the output file</param>
        /// /// <param name="output">SaveFormat of the output file</param>
        public void Convert(string output, SaveFormat OutPutType)
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Product.BaseProductUri + "/words/" + FileName;
                strURI += "?format=" + OutPutType;

                //sign URI
                string signedURI = Utils.Sign(strURI);

                //get response stream
                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                using (Stream fileStream = System.IO.File.OpenWrite(output))
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
        /// Convert Documentl to different file format without using storage
        /// </summary>
        /// <param name="outputFileName"></param>
        /// <param name="outputFormat"></param>
        public void ConvertLocalFile(string inputPath, string outputPath, SaveFormat outputFormat)
        {
            try
            {

                //build URI
                string strURI = Saaspose.Common.Product.BaseProductUri + "/words/convert?format=" + outputFormat;

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
        /// Convert Document to different file format without using storage
        /// </summary>
        /// <param name="outputFileName"></param>
        /// <param name="outputFormat"></param>
        public Stream ConvertLocalFile(Stream inputStream, SaveFormat outputFormat)
        {
            try
            {
                //build URI
                string strURI = Saaspose.Common.Product.BaseProductUri + "/words/convert?format=" + outputFormat;

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
