using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Common;
using Saaspose.Storage;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;


namespace Saaspose.Pdf
{
    /// <summary>
    /// Deals with PDF document level aspects
    /// </summary>
    public class Document
    {
        public Document(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// PDF document name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets the page count of the specified PDF document
        /// </summary>
        /// <returns>page count</returns>
        public int GetPageCount()
        {
                    //build URI to get page count
                    string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/Pages";
                    string signedURI = Utils.Sign(strURI);

                    Stream responseStream = Utils.ProcessCommand(signedURI, "GET");
                    
                    StreamReader reader = new StreamReader(responseStream);
                    string strJSON = reader.ReadToEnd();


                    //Parse the json string to JObject
                    JObject parsedJSON = JObject.Parse(strJSON);

                    
                    //Deserializes the JSON to a object. 
                    PagesResponse pagesResponse = JsonConvert.DeserializeObject<PagesResponse>(parsedJSON.ToString());

                   int count = pagesResponse.Pages.List.Count;

                   
                    return count;
        }

        /// <summary>
        /// Gets all the properties of the specified document
        /// </summary>
        /// <returns>list of properties</returns>
        public List<DocumentProperty> GetDocumentProperties()
        {

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/documentProperties";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            DocumentPropertiesResponse documentPropertiesResponse = JsonConvert.DeserializeObject<DocumentPropertiesResponse>(parsedJSON.ToString());

            return documentPropertiesResponse.DocumentProperties.List;

        }

        /// <summary>
        /// Gets the value of a particular property
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns>value of the specified property</returns>
        public DocumentProperty GetDocumentProperty(string propertyName)
        {

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/documentProperties/" + propertyName;
            string signedURI = Utils.Sign(strURI);


            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            DocumentPropertyResponse documentPropertyResponse = JsonConvert.DeserializeObject<DocumentPropertyResponse>(parsedJSON.ToString());

            return documentPropertyResponse.DocumentProperty;

        }

        /// <summary>
        /// Sets the value of a particular property
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        public bool SetDocumentProperty(string propertyName, string propertyValue)
        {

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/documentProperties/" + propertyName;
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

            DocumentPropertyResponse baseResponse = JsonConvert.DeserializeObject<DocumentPropertyResponse>(pJSON.ToString());

            if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                return true;
            else
                return false;


        }

        /// <summary>
        /// removes values of all the properties
        /// </summary>
        /// <returns></returns>
        public bool RemoveAllProperties()
        {

            //throw new Exception("Resource removeAll throws exception");

            //with POST following exception
            //throw new Exception("Exception received: The remote server returned an error: (405) Method Not Allowed");
            //if GET works then documentation needs to be updated

            //with GET following exception
            //The remote server returned an error: (400) Bad Request

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/documentProperties";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "DELETE");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

            if (baseResponse.Code == "200" && baseResponse.Status == "OK")
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gets the form field count
        /// </summary>
        /// <returns>count of the form fields</returns>
        public int GetFormFieldCount()
        {

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/fields";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            FormFieldsResponse formFieldsResponse = JsonConvert.DeserializeObject<FormFieldsResponse>(parsedJSON.ToString());

            return formFieldsResponse.Fields.List.Count;

        }

        /// <summary>
        /// Gets list of all the fields in the PDF file
        /// </summary>
        /// <returns>list of the form fields</returns>
        public List<FormField> GetFormFields()
        {

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/fields";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            FormFieldsResponse formFieldsResponse = JsonConvert.DeserializeObject<FormFieldsResponse>(parsedJSON.ToString());

            return formFieldsResponse.Fields.List;

        }

        /// <summary>
        /// Gets a particular form field
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns>form field</returns>
        public FormField GetFormField(string fieldName)
        {

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/fields/" + fieldName;
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            FormFieldResponse formFieldResponse = JsonConvert.DeserializeObject<FormFieldResponse>(parsedJSON.ToString());

            return formFieldResponse.Field;

        }




        
    }
}
