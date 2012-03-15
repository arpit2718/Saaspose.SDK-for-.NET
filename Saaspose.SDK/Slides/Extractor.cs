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
    public class Extractor
    {
        public Extractor(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Presentation name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets total number of images in a presentation
        /// </summary>
        /// <returns>Total number of images</returns>
        public int GetImageCount()
        {
            //build URI to get image count
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/images";
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
        /// Gets number of images in the specified slide
        /// </summary>
        /// <param name="slideNumber"></param>
        /// <returns></returns>
        public int GetImageCount(int slideNumber)
        {
            //build URI to get image count
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" + slideNumber.ToString() + "/images";
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
        /// Gets all shapes from the specified slide
        /// </summary>
        /// <param name="slideNumber"></param>
        /// <returns></returns>
        public List<Shape> GetShapes(int slideNumber)
        {
            //build URI to get shapes
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" + slideNumber + "/shapes";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            ShapesResponse shapesResponse = JsonConvert.DeserializeObject<ShapesResponse>(parsedJSON.ToString());

            List<Shape> shapes = new List<Shape>();
            foreach (ShapeURI shapeURI in shapesResponse.ShapeList.Links)
            {
                //Parse the json string to JObject
                JObject parsedShapeJSON = ProcessURI(shapeURI.Uri.Href);

                //Deserializes the JSON to a object. 
                ShapeResponse shapeResponse = JsonConvert.DeserializeObject<ShapeResponse>(parsedShapeJSON.ToString());
                shapes.Add(shapeResponse.Shape);
            }

            return shapes;
        }

        /// <summary>
        /// Processes URI and returns JObject
        /// </summary>
        /// <param name="strURI"></param>
        /// <returns></returns>
        private JObject ProcessURI(string strURI)
        {
            //build URI
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            return parsedJSON;
        }
    }
}
