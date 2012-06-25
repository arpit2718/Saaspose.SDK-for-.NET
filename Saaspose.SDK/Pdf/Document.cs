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

        /// <summary>
        /// Creates a Pdf from XML
        /// </summary>
        /// <param name="pdfFileName"></param>
        /// <param name="xsltFileName"></param>
        /// <param name="xmlFileName"></param>
        /// <returns></returns>
        public bool CreateFromXml(string pdfFileName, string xsltFileName, string xmlFileName)
        {
            try
            {
 
                string strURI = Product.BaseProductUri + "/pdf/" + pdfFileName + "?templateFile=" + xsltFileName + "&dataFile=" + xmlFileName + "&templateType=xml";
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "PUT"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
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
        /// Creates a Pdf from HTML
        /// </summary>
        /// <param name="pdfFileName"></param>
        /// <param name="htmlFileName"></param>
        /// <returns></returns>
        public bool CreateFromHtml(string pdfFileName, string htmlFileName)
        {
            try
            {

                string strURI = Product.BaseProductUri + "/pdf/" + pdfFileName + "?templateFile=" + htmlFileName + "&templateType=html";
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "PUT"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
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
        /// Creates an Empty Pdf document
        /// </summary>
        /// <param name="newDocumentName"></param>
        /// <returns></returns>

        public  bool CreateEmptyPdf(String newDocumentName)
        {

            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + newDocumentName;
                string signedURI = Utils.Sign(strURI);



                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "PUT"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
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
        /// Appends two Pdf documents. The newPdf is appended at the end of basePdf
        /// </summary>
        /// <param name="basePdf"></param>
        /// <param name="newPdf"></param>
        /// <returns></returns>

        public bool AppendDocument(string basePdf, string newPdf)
        {

            try
            {
                //Saving Exisiting File name
                String sOldFile=FileName;

                //Getting Total page in PDF
                FileName = newPdf;
                int iPageCount = GetPageCount();
               
                //Setting Old File name again
                FileName = sOldFile;

                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + basePdf + "/appendDocument?appendFile="+newPdf+"&startPage=1&endPage="+iPageCount.ToString();
                string signedURI = Utils.Sign(strURI);
                

                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
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
        /// Appends two Pdf documents. The start and end pages number newPdf is given and it is appended at the end of basePdf
        /// </summary>
        /// <param name="basePdf"></param>
        /// <param name="newPdf"></param>
        /// <param name="startPage"></param>
        /// <param name="endPage"></param>
        /// <returns></returns>

        public bool AppendDocument(string basePdf, string newPdf, int startPage, int endPage)
        {

            try
            {
 
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + basePdf + "/appendDocument/?appendFile=" + newPdf + "&startPage=" + startPage.ToString() + "&endPage=" + endPage.ToString();
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
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
        /// Adds new page to opened Pdf document
        /// </summary>
        /// <returns></returns>
       
        public bool AddNewPage()
        {

            try
            {
 
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages";
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "PUT"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
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
        /// Deletes selected page in Pdf document
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>

        public bool DeletePage(int pageNumber)
        {
            try
            {

                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/"+pageNumber.ToString();
                string signedURI = Utils.Sign(strURI);


                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "DELETE"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
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
        /// Moves selected page in Pdf document to new location
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="newLocation"></param>
        /// <returns></returns>
        public bool MovePage(int pageNumber, int newLocation)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/movePage?newIndex=" + newLocation.ToString();
                string signedURI = Utils.Sign(strURI);

                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
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
        /// Replace Image in PDF File using Local Image Stream
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="newLocation"></param>
        /// <returns></returns>
        public bool ReplaceImageUsingStream(int pageNumber, int imageIndex, Stream imageStream)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/images/" + imageIndex.ToString();
               
                string signedURI = Utils.Sign(strURI);
                
                Stream responseStream = Utils.ProcessCommand(signedURI, "POST", imageStream);

                StreamReader reader = new StreamReader(responseStream);

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
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
        /// Replace Image in PDF document using Image File uploaded on Server
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="newLocation"></param>
        /// <returns></returns>
        public bool ReplaceImageUsingFile(int pageNumber, int imageIndex, string fileName)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/images/" + imageIndex.ToString() + "?imageFile=" + fileName;

                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "POST");

                StreamReader reader = new StreamReader(responseStream);

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                BaseResponse stream = JsonConvert.DeserializeObject<BaseResponse>(parsedJSON.ToString());

                if (stream.Code == "200" && stream.Status == "OK")
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
