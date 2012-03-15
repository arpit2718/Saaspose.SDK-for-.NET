using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.IO;

using Saaspose.Common;

namespace Saaspose.Pdf
{
    /// <summary>
    /// Extract various types of information from the document
    /// </summary>
    public class Extractor
    {
        public Extractor(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// PDF document name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets number of images in a specified page
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public int GetImageCount(int pageNumber)
        {
            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/images";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();


            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            ImagesResponse imagesResponse = JsonConvert.DeserializeObject<ImagesResponse>(parsedJSON.ToString());

            return imagesResponse.Images.List.Count;

        }

        /// <summary>
        /// Get the particular image from the specified page
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="pageNumber"></param>
        public void GetImage(string outputPath, int pageNumber, int imageIndex, ExtractImageFormat imageFormat, SaveLocation saveLocation, int imageHeight, int imageWidth)
        {

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/images/" + imageIndex.ToString();
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
        /// Get the particular image from the specified page with the default image size
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="pageNumber"></param>
        public void GetImage(string outputPath, int pageNumber, int imageIndex, ExtractImageFormat imageFormat, SaveLocation saveLocation)
        {

            //build URI to get page count
            string strURI = Product.BaseProductUri + "/pdf/" + FileName + "/pages/" + pageNumber.ToString() + "/images/" + imageIndex.ToString();
            strURI += "?format=" + imageFormat;


            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
            {
                Utils.CopyStream(responseStream, fileStream);
            }
            responseStream.Close();

        }

 

    }
}
