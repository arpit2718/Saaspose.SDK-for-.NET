using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Common;
using Saaspose.Storage;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Saaspose.Cells
{
    public class Workbook
    {        
       
        /// <summary>
        /// Workbook Constructor, set the file name and password
        /// </summary>
        /// <param name="fileName"> File Name</param>
        public Workbook(string fileName)
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
                string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
                strURI += "/documentProperties";

                //sign URI
                string signedURI = Utils.Sign(strURI);

                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Create list of document properties
                List<Saaspose.Cells.DocumentProperty> properties = new List<Saaspose.Cells.DocumentProperty>();

                //Deserializes the JSON to a object. 
                WorkbookResponse docResponse = JsonConvert.DeserializeObject<WorkbookResponse>(parsedJSON.ToString());

                properties = docResponse.DocumentProperties.DocumentPropertyList;
                                
                //return document properties
                return properties;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get a Particular Property
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public DocumentProperty GetProperty(string propertyName)
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
                strURI += "/documentProperties/" + propertyName;

                //sign URI
                string signedURI = Utils.Sign(strURI);

                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Deserializes the JSON to a object. 
                WorkbookResponse docResponse = JsonConvert.DeserializeObject<WorkbookResponse>(parsedJSON.ToString());

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
        public void SetProperty(string propertyName, string propertyValue)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/cells/" + FileName + "/documentProperties/" + propertyName;
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

                WorkbookResponse baseResponse = JsonConvert.DeserializeObject<WorkbookResponse>(pJSON.ToString());
              

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public bool RemoveAllProperties()
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
                strURI += "/documentProperties";

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

        public bool RemoveProperty(string propertyName)
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
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
        /// 
        /// </summary>
        /// <param name="newWorkbookName"></param>
        public void CreateEmptyWorkbook()
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/cells/" + FileName;
                string signedURI = Utils.Sign(strURI);
            

                Stream responseStream = Utils.ProcessCommand(signedURI, "PUT");

                StreamReader reader = new StreamReader(responseStream);
                string strResponse = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject pJSON = JObject.Parse(strResponse);

                WorkbookResponse baseResponse = JsonConvert.DeserializeObject<WorkbookResponse>(pJSON.ToString());


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CreateWorkbookFromTemplate(string templateFileName)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/cells/" + FileName + "?templatefile=" + templateFileName;
                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "PUT");

                StreamReader reader = new StreamReader(responseStream);
                string strResponse = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject pJSON = JObject.Parse(strResponse);

                WorkbookResponse baseResponse = JsonConvert.DeserializeObject<WorkbookResponse>(pJSON.ToString());


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newWorkbookName"></param>
        /// <param name="templateFileName"></param>
        /// <param name="dataFile"></param>
        public void CreateWorkbookFromSmartMarkerTemplate(string templateFileName, string dataFile)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/cells/" + FileName + "?templatefile=" + templateFileName + "&dataFile=" + dataFile;
                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "PUT");

                StreamReader reader = new StreamReader(responseStream);
                string strResponse = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject pJSON = JObject.Parse(strResponse);

                WorkbookResponse baseResponse = JsonConvert.DeserializeObject<WorkbookResponse>(pJSON.ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ProcessSmartMarker(string dataFile)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/cells/" + FileName + "/smartmarker?xmlFile=" + dataFile;
                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "POST");

                StreamReader reader = new StreamReader(responseStream);
                string strResponse = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject pJSON = JObject.Parse(strResponse);

                WorkbookResponse baseResponse = JsonConvert.DeserializeObject<WorkbookResponse>(pJSON.ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int GetWorksheetsCount()
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorkbookResponse docResponse = JsonConvert.DeserializeObject<WorkbookResponse>(parsedJSON.ToString());

            return docResponse.Worksheets.WorksheetList.Count;
        }
      
        public int GetNamesCount()
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/names";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);
                     
            //Deserializes the JSON to a object. 
            WorkbookResponse docResponse = JsonConvert.DeserializeObject<WorkbookResponse>(parsedJSON.ToString());

            return docResponse.Names.Count;

        }

        public Style getDefaultStyle()
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/defaultStyle";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorkbookResponse docResponse = JsonConvert.DeserializeObject<WorkbookResponse>(parsedJSON.ToString());

            //return default Style
            return docResponse.Style;
        }

        public bool EncryptWorkbook(EncryptionType encryptionType, string password, int keyLength)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/cells/" + FileName + "/encryption";
                string signedURI = Utils.Sign(strURI);

                //serialize the JSON request content
                Encryption encyption = new Encryption();
                encyption.EncryptionType = encryptionType;
                encyption.Password = password;
                encyption.Keylength = keyLength;
                string strJSON = JsonConvert.SerializeObject(encyption);

                Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strJSON);

                StreamReader reader = new StreamReader(responseStream);
                string strResponse = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject pJSON = JObject.Parse(strResponse);

                BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(pJSON.ToString());

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

        public bool ProtectWorkbook(ProtectionType protectionType, string password)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/cells/" + FileName + "/protection";
                string signedURI = Utils.Sign(strURI);

                //serialize the JSON request content
                Protection protection = new Protection();
                protection.ProtectionType = protectionType;
                protection.Password = password;
              
                string strJSON = JsonConvert.SerializeObject(protection);

                Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strJSON);

                StreamReader reader = new StreamReader(responseStream);
                string strResponse = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject pJSON = JObject.Parse(strResponse);

                BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(pJSON.ToString());

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

        public bool UnprotectWorkbook(string password)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/cells/" + FileName + "/protection";
                string signedURI = Utils.Sign(strURI);

                //serialize the JSON request content
                Protection protection = new Protection();
                protection.Password = password;

                string strJSON = JsonConvert.SerializeObject(protection);

                Stream responseStream = Utils.ProcessCommand(signedURI, "DELETE", strJSON);

                StreamReader reader = new StreamReader(responseStream);
                string strResponse = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject pJSON = JObject.Parse(strResponse);

                BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(pJSON.ToString());

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

        public bool SetModifyPassword(string password)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/cells/" + FileName + "/writeProtection";
                string signedURI = Utils.Sign(strURI);

                //serialize the JSON request content
                Protection protection = new Protection();
                protection.Password = password;
                string strJSON = JsonConvert.SerializeObject(protection);

                Stream responseStream = Utils.ProcessCommand(signedURI, "PUT", strJSON);

                StreamReader reader = new StreamReader(responseStream);
                string strResponse = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject pJSON = JObject.Parse(strResponse);

                BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(pJSON.ToString());

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
        public bool ClearModifyPassword(string password)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/cells/" + FileName + "/writeProtection";
                string signedURI = Utils.Sign(strURI);

                //serialize the JSON request content
                string strJSON = JsonConvert.SerializeObject(password);

                Stream responseStream = Utils.ProcessCommand(signedURI, "DELETE", strJSON);

                StreamReader reader = new StreamReader(responseStream);
                string strResponse = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject pJSON = JObject.Parse(strResponse);

                BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(pJSON.ToString());

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
        public bool DecryptWorkbook(string password)
        {

            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/cells/" + FileName + "/encryption";
                string signedURI = Utils.Sign(strURI);

                //serialize the JSON request content
                Encryption encyption = new Encryption();
                
                encyption.Password = password;
                
                string strJSON = JsonConvert.SerializeObject(encyption);

                Stream responseStream = Utils.ProcessCommand(signedURI, "Delete", strJSON);

                StreamReader reader = new StreamReader(responseStream);
                string strResponse = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject pJSON = JObject.Parse(strResponse);

                BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(pJSON.ToString());
              
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
        /// 
        /// </summary>
        /// <param name="worksheetName"></param>

        public bool AddWorksheet(string worksheetName)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/cells/" + FileName + "/worksheets/" + worksheetName;
                string signedURI = Utils.Sign(strURI);



                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "PUT"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (baseResponse.Code == "201" && baseResponse.Status == "CREATED")
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
        /// 
        /// </summary>
        /// <param name="worksheetName"></param>
        /// <returns></returns>
        public bool RemoveWorksheet(string worksheetName)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + worksheetName;

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

        public void MergeWorkbook(string mergefileName)
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
                strURI += "/merge?mergeWith=" + mergefileName;

                //sign URI
                string signedURI = Utils.Sign(strURI);

                //get response stream
                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Deserializes the JSON to a object. 
                WorkbookResponse docResponse = JsonConvert.DeserializeObject<WorkbookResponse>(parsedJSON.ToString());

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }      

        /// <summary>
        /// Workbook name
        /// </summary>
        public string FileName { get; set; }
       

    }
}
