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

 
    }
}
