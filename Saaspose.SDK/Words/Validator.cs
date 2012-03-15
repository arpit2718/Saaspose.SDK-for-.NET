using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Storage;
using Saaspose.Common;
using System.IO;

namespace Saaspose.Words
{
    /// <summary>
    /// Performs any validation related tasks
    /// </summary>
    public class Validator
    {
        public Validator(string fileName)
        {
            //set default values
            FileName = fileName;
        }

        /// <summary>
        /// get or set file name
        /// </summary>
        public string FileName { get; set; }


        /// <summary>
        /// Performs input validation on the client end or local server
        /// </summary>
        public static void LocalValidation()
        {
            try
            {
                // Throws exception if product server is not specified
                if (Product.BaseProductUri + "/words/" == null || (Product.BaseProductUri + "/words/").ToString().Trim().Length == 0)
                    throw new Exception("App Server is not specified. Please set Server property.");

                // Throw exception if App Key is empty
                if (SaasposeApp.AppKey == null || SaasposeApp.AppKey.Trim().Length == 0)
                    throw new Exception("App Key is not specified. Please set the App Key property.");

                // Throw exception if App SID is empty
                if (SaasposeApp.AppSID == null || SaasposeApp.AppSID.Trim().Length == 0)
                    throw new Exception("App SID is not specified. Please set App SID property.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Performs validation of the response from the remote server
        /// </summary>
        public static void RemoteValidation(string fileName)
        {
            throw new Exception("This method is not yet implemented");
        }

        public Boolean validateFile()
        {

            //foreach (string type in Enum.GetNames(typeof(ConversionType)))
            //{
            //    if (Path.GetExtension(FileName).ToLower() == "." + type.ToLower())
            //        return true;
            //}

            //return false;

            if (Path.GetExtension(FileName).ToLower() == "." +  SaveFormat.Doc.ToString().ToLower() || Path.GetExtension(FileName).ToLower() == "." + SaveFormat.Docx.ToString().ToLower())
                return true;
            else
                return false;
        }
    }
}
