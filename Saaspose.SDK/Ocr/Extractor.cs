using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Common;
using Saaspose.Storage;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Saaspose.OCR
{
    public class Extractor
    {
        public Extractor() { }
        /// <summary>
        /// Extract image text using default settings.
        /// </summary>
        /// <param name="fileName">The image file name.</param>
        /// <param name="folder">The image file folder.</param>
        /// <returns><see cref="OCRResponse"/> with the operation result.</returns>
        public OCRResponse ExtractText(string imageFileName, string folder = null)
        {
            //build URI to extract text
            string strURI = "";
            if (folder == null || folder == string.Empty)
                strURI = Product.BaseProductUri + "/ocr/" + imageFileName + "/recognize";
            else
                strURI = Product.BaseProductUri + "/ocr/" + imageFileName + "/recognize?folder=" + folder;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            //execute signed URI request and get response
            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            OCRResponse ocrResponse = JsonConvert.DeserializeObject<OCRResponse>(parsedJSON.ToString());

            return ocrResponse;
        }
        /// <summary>
        /// Extract image text using specific language.
        /// </summary>
        /// <param name="fileName">The image file name.</param>
        /// <param name="language">The language.</param>
        /// <param name="useDefaultDictionaries">Use default dictionaries or not.</param>
        /// <param name="folder">The image folder.</param>
        /// <returns><see cref="OCRResponse"/> with the operation result.</returns>
        public OCRResponse ExtractText(string imageFileName, LanguageName language, bool useDefaultDictionaries = false, string folder = null)
        {
            //build URI to extract text
            string strURI = "";
            if (string.IsNullOrEmpty(folder))
                strURI = Product.BaseProductUri + "/ocr/" + imageFileName + "/recognize?language=" + language + "&useDefaultDictionaries=" + useDefaultDictionaries;
            else
                strURI = Product.BaseProductUri + "/ocr/" + imageFileName + "/recognize?language=" + language + "&useDefaultDictionaries=" + useDefaultDictionaries + "&folder=" + folder;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            //execute signed URI request and get response
            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            OCRResponse ocrResponse = JsonConvert.DeserializeObject<OCRResponse>(parsedJSON.ToString());

            return ocrResponse;
        }
        /// <summary>
        /// Extract image text from local file.
        /// </summary>
        /// <param name="localFile">The local file.</param>
        /// <param name="language">The text language.</param>
        /// <param name="useDefaultDictionaries">Use default dictionaries or not.</param>
        /// <returns><see cref="OCRResponse"/> with the operation result.</returns>
        public OCRResponse ExtractText(string localFile, LanguageName language, bool useDefaultDictionaries = false)
        {
            //build URI to extract text
            string strURI = strURI = Product.BaseProductUri + "/ocr/recognize?language=" + language + "&useDefaultDictionaries=" + useDefaultDictionaries;

            //sign URI
            string signedURI = Utils.Sign(strURI);
            FileStream stream = new FileStream(localFile, FileMode.Open, FileAccess.Read);

            //execute signed URI request and get response
            Stream responseStream = Utils.ProcessCommand(signedURI, "POST", stream);

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            OCRResponse ocrResponse = JsonConvert.DeserializeObject<OCRResponse>(parsedJSON.ToString());

            return ocrResponse;
        }
        /// <summary>
        /// Extract image text from stream.
        /// </summary>
        /// <param name="stream">The stream with image data.</param>
        /// <param name="language">Language.</param>
        /// <param name="useDefaultDictionaries">Use default dictionaries or not.</param>
        /// <returns><see cref="OCRResponse"/> with the operation result.</returns>
        public OCRResponse ExtractText(Stream stream, LanguageName language, bool useDefaultDictionaries = false)
        {
            //build URI to extract text
            string strURI = strURI = Product.BaseProductUri + "/ocr/recognize?language=" + language + "&useDefaultDictionaries=" + useDefaultDictionaries;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            //execute signed URI request and get response
            Stream responseStream = Utils.ProcessCommand(signedURI, "POST", stream);

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            OCRResponse ocrResponse = JsonConvert.DeserializeObject<OCRResponse>(parsedJSON.ToString());

            return ocrResponse;
        }

        /// <summary>
        /// Scans whole or part of images and extracts OCR text
        /// </summary>
        /// <param name="imageFileName">Name of the image file</param>
        public OCRResponse ExtractText(string imageFileName)
        {
            //build URI to extract text
            string strURI = Product.BaseProductUri + "/ocr/" + imageFileName + "/recognize?useDefaultDictionaries=true";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            //execute signed URI request and get response
            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            OCRResponse ocrResponse = JsonConvert.DeserializeObject<OCRResponse>(parsedJSON.ToString());

            return ocrResponse;
        }

        /// <summary>
        /// Scans whole or part of images and extracts OCR text
        /// </summary>
        /// <param name="imageFileName">Name of the image file</param>
        /// <param name="language">Language of document to recognize</param>
        /// /// <param name="useDefaultDictionaries">Allows to correct text after recognition using default dictionaries</param>
        /// /// <param name="x">Start x of the rectangle: Recognition of text inside specified Rectangle region</param>
        /// /// <param name="y">Start y of the rectangle: Recognition of text inside specified Rectangle region</param>
        /// /// <param name="width">Width of the rectangle: Recognition of text inside specified Rectangle region</param>
        /// /// <param name="height">Height of the rectangle: Recognition of text inside specified Rectangle region</param>
        /// /// <param name="folder">Folder with images to recognize</param>
        /// <returns></returns>
        public OCRResponse ExtractText(string imageFileName, LanguageName language, bool useDefaultDictionaries, int x, int y,
            int width, int height, string folder)
        {
            //build URI to extract text
            string strURI = Product.BaseProductUri + "/ocr/" + imageFileName + "/recognize?language=" + language +
                ((x >= 0 && y >= 0 && width > 0 && height > 0) ? "&rectX=" + x + "&rectY=" + y + "&rectWidth=" + width + "&rectHeight=" + height : "") +
             "&useDefaultDictionaries=" + ((useDefaultDictionaries) ? "true" : "false") +
             ((string.IsNullOrEmpty(folder)) ? "" : "&folder=" + folder);

            //sign URI
            string signedURI = Utils.Sign(strURI);

            //execute signed URI request and get response
            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            OCRResponse ocrResponse = JsonConvert.DeserializeObject<OCRResponse>(parsedJSON.ToString());

            return ocrResponse;
        }

        /// <summary>
        /// Extract Text from remote image URL.
        /// </summary>
        /// <param name="url">The image url.</param>
        /// <param name="language">The specific language.</param>
        /// <param name="useDefaultDictionaries">Use default dictionaries or not.</param>
        /// <returns><see cref="OCRResponse"/> with the operation result.</returns>
        public OCRResponse ExtractTextFromURL(string url, LanguageName language, bool useDefaultDictionaries = false)
        {
            //build URI to extract text
            string strURI = Product.BaseProductUri + "/ocr/recognize?url=" + url + "&language=" + language + "&useDefaultDictionaries=" + useDefaultDictionaries;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            //execute signed URI request and get response
            Stream responseStream = Utils.ProcessCommand(signedURI, "POST");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            OCRResponse ocrResponse = JsonConvert.DeserializeObject<OCRResponse>(parsedJSON.ToString());

            return ocrResponse;
        }
    }
}
