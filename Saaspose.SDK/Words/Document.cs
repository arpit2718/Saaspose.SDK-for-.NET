using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Common;
using Saaspose.Storage;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Saaspose.Words;

namespace Saaspose.Words
{
    /// <summary>
    /// Deals with document level aspects
    /// </summary>
    public class Document 
    {

        /// <summary>
        /// document name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The original format of the file.
        /// </summary>
        public string SourceFormat { get; set; }

        /// <summary>
        /// Returns true if the document is encrypted and requires a password to open
        /// </summary>
        public string IsEncrypted { get; set; }

        /// <summary>
        /// Returns true if the document contains a digital signature.
        /// </summary>
        public string IsSigned { get; set; }

        /// <summary>
        /// Document Properties Response
        /// </summary>
        public DocumentPropertiesResponse documentproperties { get; set; }

        /// <summary>
        /// Link Response related to document like
        /// <link href="http://api.saaspose.com/v1.0/words/TestGet.doc/documentProperties" rel="self" />
        /// </summary>
        public List<LinkResponse> links { get; set; }
        
        /// <summary>
        /// Document Constructor, set the file name
        /// </summary>
        /// <param name="fileName"> File Name</param>
        public Document(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Get Document's properties
        /// </summary>
        /// <returns>List of document properties</returns>
        public List<DocumentProperty> GetProperties()
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Product.BaseProductUri + "/words/" + FileName;
                strURI += "/documentProperties";

                //sign URI
                string signedURI = Utils.Sign(strURI);

                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));
                
                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Create list of document properties
                List<Saaspose.Words.DocumentProperty> properties = new List<Saaspose.Words.DocumentProperty>();

                //Deserializes the JSON to a object. 
                DocumentResponse docResponse = JsonConvert.DeserializeObject<DocumentResponse>(parsedJSON.ToString());

                properties = docResponse.DocumentProperties.List;

                //return document properties
                return properties;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DocumentProperty GetProperty(string propertyName)
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Product.BaseProductUri + "/words/" + FileName;
                strURI += "/documentProperties/" + propertyName;

                //sign URI
                string signedURI = Utils.Sign(strURI);

                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Deserializes the JSON to a object. 
                DocumentResponse docResponse = JsonConvert.DeserializeObject<DocumentResponse>(parsedJSON.ToString());

                //return document property
                return docResponse.DocumentProperty;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Set document property
        /// </summary>
        /// <param name="propertyName">property name</param>
        /// <param name="propertyValue">property value</param>
        public Boolean SetProperty(string propertyName, string propertyValue)
        {
            try
            {
                string strURI = Product.BaseProductUri + "/words/" + FileName + "/documentProperties/" + propertyName;
                string signedURI = Utils.Sign(strURI);

                //serialize the JSON request content
                DocumentProperty docProperty = new DocumentProperty();
                docProperty.Value = propertyValue;
                string strJSON = JsonConvert.SerializeObject(docProperty);

                Stream responseStream = Utils.ProcessCommand(signedURI, "PUT", strJSON);

                StreamReader reader = new StreamReader(responseStream);
                string strResponse = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject pJSON = JObject.Parse(strResponse);

                DocumentResponse baseResponse = JsonConvert.DeserializeObject<DocumentResponse>(pJSON.ToString());

                if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete a document property
        /// </summary>
        /// <param name="propertyName">Property Name</param>
        /// <returns></returns>
        public Boolean DeleteProperty(string propertyName)
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Product.BaseProductUri + "/words/" + FileName;
                strURI += "/documentProperties/" + propertyName;

                //sign URI
                string signedURI = Utils.Sign(strURI);

                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "DELETE"));
                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Deserializes the JSON to a object. 
                BaseResponse docResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (docResponse.Status == "OK")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Resource Properties information like document source format, IsEncrypted, IsSigned and document properties
        /// </summary>
        /// <returns></returns>
        public DocumentResourceResponse GetDocumentInfo()
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Product.BaseProductUri + "/words/" + FileName;
                //strURI += "/document";

                //sign URI
                string signedURI = Utils.Sign(strURI);

                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));
                
                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Deserializes the JSON to a object. 
                DocumentResourceResponse docResponse = JsonConvert.DeserializeObject<DocumentResourceResponse>(parsedJSON.ToString());

                //Return document info response
                return docResponse;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Append a list of documents to this one.
        /// </summary>
        /// <param name="outputFileName"></param>
        /// <param name="outputFormat"></param>
        public Boolean AppendDocument(string[] appendDocs, string[] importFormatModes, string folder)
        {

            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //check whether required information is complete
            if (appendDocs.Length != importFormatModes.Length)
                throw new Exception("Please specify complete documents and import format modes");

            try
            {
                //Create DocumentEntryList object
                DocumentEntryList list = new DocumentEntryList();
                list.DocumentEntries = new List<DocumentEntry>();
                for (int i = 0; i < appendDocs.Length; i++)
                {
                    string appendDoc = appendDocs[i];
                    string docServerPath = Path.Combine(folder, appendDoc);
                    list.DocumentEntries.Add(new DocumentEntry(docServerPath, importFormatModes[i]));
                }

                //Extract File Name
                string inputFileName = System.IO.Path.GetFileName(FileName);

                //build URI
                Uri uri = new Uri(Product.BaseProductUri + "/words/" + inputFileName + "/appendDocument");
                UriBuilder builder = new UriBuilder(uri);
                if (!string.IsNullOrEmpty(folder))
                    builder.Query = string.Format("folder={0}", folder);

                //sign URI
                string signedURI = Utils.Sign(builder.Uri.AbsoluteUri);
                string strJSON = JsonConvert.SerializeObject(list);
                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST", strJSON));

                //further process JSON response
                string ResJSONStr = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(ResJSONStr);

                //Deserializes the JSON to a object. 
                BaseResponse docResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (docResponse.Status == "OK")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
