using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Common;
using Saaspose.Storage;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Saaspose.Slides
{
    /// <summary>
    /// Deals with PowerPoint presentation level aspects
    /// </summary>
    public class Document
    {
        public Document(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Presentation name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Finds the slide count of the specified PowerPoint document
        /// </summary>
        /// <returns>slide count</returns>
        public int GetSlideCount()
        {
            //build URI to get slide count
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            SlidesResponse slidesResponse = JsonConvert.DeserializeObject<SlidesResponse>(parsedJSON.ToString());

            int count = slidesResponse.Slides.SlideList.Count;
            return count;
        }

        /// <summary>
        /// Gets a list containing all document properties
        /// </summary>
        /// <returns>List of document properties</returns>
        public List<DocumentProperty> GetDocumentProperties()
        {
            //build URI to get document properties
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/documentProperties";
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

            //build URI to get single property
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/presentation/documentProperties/" + propertyName;
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
        /// Removes all the custom properties and resets all the built-in properties
        /// </summary>
        public bool RemoveAllProperties()
        {

            //build URI to remove/reset all the properties
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/documentProperties";
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
        /// Replaces all instances of old text with new text in a presentation
        /// </summary>
        /// <param name="oldText"></param>
        /// <param name="newText"></param>
        public bool ReplaceText(string oldText, string newText)
        {
            //build URI to replace text
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/replaceText?oldValue=" +
                oldText + "&newValue=" + newText + "&ignoreCase=true";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "POST");
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
        /// Replaces all instances of old text with new text in a slide
        /// </summary>
        /// <param name="oldText"></param>
        /// <param name="newText"></param>
        /// <param name="slideNumber"></param>
        public bool ReplaceText(string oldText, string newText, int slideNumber)
        {
            //build URI to replace text in a particular slide
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" + slideNumber + "/replaceText?oldValue=" +
                oldText + "&newValue=" + newText + "&ignoreCase=true";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "POST");
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
        /// Deletes a particular custom property or resets a particular built-in property
        /// </summary>
        /// <param name="propertyName"></param>
        public bool DeleteDocumentProperty(string propertyName)
        {

            //build URI to remove single property
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/documentProperties/" + propertyName;
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
        /// Gets all the text items in a presentation
        /// </summary>
        /// <returns>A list containing all the text items</returns>
        public List<TextItem> GetAllTextItems()
        {
            //build URI to get all text items in a presentation
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/textItems";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            TextItemsResponse textItemsResponse = JsonConvert.DeserializeObject<TextItemsResponse>(parsedJSON.ToString());

            return textItemsResponse.TextItems.Items;
        }

        /// <summary>
        /// Gets all the text items in a slide
        /// </summary>
        /// <param name="slideNumber"></param>
        /// /// <param name="withEmpty">Set this to true to include items for shapes without text</param>
        /// <returns>A list containing all the text items in a slide</returns>
        public List<TextItem> GetAllTextItems(int slideNumber, bool withEmpty)
        {
            //build URI to get all text items in a slide
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" + slideNumber + "/textItems?withEmpty=" + withEmpty;
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            TextItemsResponse textItemsResponse = JsonConvert.DeserializeObject<TextItemsResponse>(parsedJSON.ToString());

            return textItemsResponse.TextItems.Items;
        }

        /// <summary>
        /// saves the document into various formats
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="saveFormat"></param>
        public void SaveAs(string outputPath, SaveFormat saveFormat)
        {

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/slides/" + FileName;
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
        /// Saves a particular slide into various formats
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="slideNumber"></param>
        /// <param name="imageFormat"></param>
        public void SaveSlideAs(string outputPath, int slideNumber, ImageFormat imageFormat)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" +
                slideNumber + "?format=" + imageFormat;

            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
            {
                Utils.CopyStream(responseStream, fileStream);
            }
            responseStream.Close();
        }

        /// <summary>
        /// Saves a particular slide into various formats with specified width and height
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="slideNumber"></param>
        /// <param name="imageFormat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SaveSlideAs(string outputPath, int slideNumber, ImageFormat imageFormat, int width, int height)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" +
                slideNumber + "?format=" + imageFormat + "&width=" + width + "&height=" + height;

            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
            {
                Utils.CopyStream(responseStream, fileStream);
            }
            responseStream.Close();
        }

        /// <summary>
        /// Sets the value of a particular property or adds a new property if the specified property does not exist
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public bool SetDocumentProperty(string propertyName, string value)
        {

            //build URI to remove single property
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/documentProperties/" + propertyName;
            string signedURI = Utils.Sign(strURI);

            //serialize the JSON request content
            DocumentProperty docProperty = new DocumentProperty();
            docProperty.Value = value;
            string strJSON = JsonConvert.SerializeObject(docProperty);

            Stream responseStream = Utils.ProcessCommand(signedURI, "PUT", strJSON);
            StreamReader reader = new StreamReader(responseStream);
            string strResponse = reader.ReadToEnd();
            //Parse the json string to JObject
            JObject pJSON = JObject.Parse(strResponse);

            DocumentPropertyResponse baseResponse = JsonConvert.DeserializeObject<DocumentPropertyResponse>(pJSON.ToString());

            if ((baseResponse.Code == "200" && baseResponse.Status == "OK") || (baseResponse.Code == "201" && baseResponse.Status == "Created"))
                return true;
            else
                return false;
        }

    }
}
