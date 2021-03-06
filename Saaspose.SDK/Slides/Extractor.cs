﻿using System;
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
        /// Gets total number of images in a presentation from a 3rd party storage
        /// </summary>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        /// <param name="folderName">In case of Amazon S3 storage the folder's path starts with Amazon S3 Bucket name.</param>
        /// <returns>Total number of images</returns>
        public int GetImageCount(StorageType storageType, string storageName, string folderName)
        {
            //build URI to get image count
            StringBuilder strURI = new StringBuilder(Product.BaseProductUri + "/slides/" + FileName
                + "/images" + (string.IsNullOrEmpty(folderName) ? "" : "?folder=" + folderName));

            switch (storageType)
            {
                case StorageType.AmazonS3:
                    strURI.Append("&storage=" + storageName);
                    break;
            }
            string signedURI = Utils.Sign(strURI.ToString());

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
        /// Gets number of images in the specified slide from a 3rd party storage
        /// </summary>
        /// <param name="slideNumber"></param>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        /// <param name="folderName">In case of Amazon S3 storage the folder's path starts with Amazon S3 Bucket name.</param>
        /// <returns></returns>
        public int GetImageCount(int slideNumber, StorageType storageType, string storageName, string folderName)
        {
            //build URI to get image count
            StringBuilder strURI = new StringBuilder(Product.BaseProductUri + "/slides/" + FileName
                + "/slides/" + slideNumber.ToString() + "/images" +
                (string.IsNullOrEmpty(folderName) ? "" : "?folder=" + folderName));

            switch (storageType)
            {
                case StorageType.AmazonS3:
                    strURI.Append("&storage=" + storageName);
                    break;
            }

            string signedURI = Utils.Sign(strURI.ToString());

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
        /// Gets all shapes in a slide from a 3rd party storage
        /// </summary>
        /// <param name="slideNumber"></param>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        /// <param name="folderName">In case of Amazon S3 storage the folder's path starts with Amazon S3 Bucket name.</param>
        /// <returns></returns>
        public List<Shape> GetShapes(int slideNumber, StorageType storageType, string storageName, string folderName)
        {
            //build URI to get shapes
            StringBuilder strURI = new StringBuilder(Product.BaseProductUri + "/slides/" + FileName
                + "/slides/" + slideNumber + "/shapes" +
                (string.IsNullOrEmpty(folderName) ? "" : "?folder=" + folderName));

            switch (storageType)
            {
                case StorageType.AmazonS3:
                    strURI.Append("&storage=" + storageName);
                    break;
            }
            string signedURI = Utils.Sign(strURI.ToString());

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
                StringBuilder uri = new StringBuilder(shapeURI.Uri.Href +
                (string.IsNullOrEmpty(folderName) ? "" : "?folder=" + folderName));

                switch (storageType)
                {
                    case StorageType.AmazonS3:
                        uri.Append("&storage=" + storageName);
                        break;
                }
                //Parse the json string to JObject
                JObject parsedShapeJSON = ProcessURI(uri.ToString());

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
        /// <summary>
        /// Get color scheme from the specified slide
        /// </summary>
        /// <param name="slideNumber"></param>
        /// <returns></returns>
        public ColorScheme GetColorScheme(int slideNumber)
        {
            //build URI to get color scheme
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" + slideNumber + "/theme/colorScheme";

            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            ColorSchemeResponse colorSchemeResponse = JsonConvert.DeserializeObject<ColorSchemeResponse>(parsedJSON.ToString());
            return colorSchemeResponse.ColorScheme;
        }

        /// <summary>
        /// Gets color scheme from the specified slide of a presentation from a third party storage
        /// </summary>
        /// <param name="slideNumber"></param>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        /// <returns></returns>
        public ColorScheme GetColorScheme(int slideNumber, StorageType storageType, string storageName)
        {
            //Build URI to get color scheme
            StringBuilder strURI = new StringBuilder(Product.BaseProductUri + "/slides/" + 
                FileName + "/slides/" + slideNumber + "/theme/colorScheme");

            switch (storageType)
            {
                case StorageType.AmazonS3:
                    strURI.Append("?storage=" + storageName);
                    break;
            }

            string signedURI = Utils.Sign(strURI.ToString());

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            ColorSchemeResponse colorSchemeResponse = JsonConvert.DeserializeObject<ColorSchemeResponse>(parsedJSON.ToString());
            return colorSchemeResponse.ColorScheme;
        }

        /// <summary>
        /// Get font scheme from the specified slide
        /// </summary>
        /// <param name="slideNumber"></param>
        /// <returns></returns>
        public FontScheme GetFontScheme(int slideNumber)
        {
            //build URI to get font scheme
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" + slideNumber + "/theme/fontScheme";

            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            FontSchemeResponse fontSchemeResponse = JsonConvert.DeserializeObject<FontSchemeResponse>(parsedJSON.ToString());
            return fontSchemeResponse.FontScheme;
        }

        /// <summary>
        /// Get font scheme from the specified slide of a presentation from a third party storage
        /// </summary>
        /// <param name="slideNumber"></param>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        /// <returns></returns>
        public FontScheme GetFontScheme(int slideNumber, StorageType storageType, string storageName)
        {
            //build URI to get font scheme
            StringBuilder strURI = new StringBuilder(Product.BaseProductUri + "/slides/" +
                FileName + "/slides/" + slideNumber + "/theme/fontScheme");

            switch (storageType)
            {
                case StorageType.AmazonS3:
                    strURI.Append("?storage=" + storageName);
                    break;
            }

            string signedURI = Utils.Sign(strURI.ToString());

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            FontSchemeResponse fontSchemeResponse = JsonConvert.DeserializeObject<FontSchemeResponse>(parsedJSON.ToString());
            return fontSchemeResponse.FontScheme;
        }
        /// <summary>
        /// Get format scheme from the specified slide
        /// </summary>
        /// <param name="slideNumber"></param>
        /// <returns></returns>
        public void GetFormatScheme(int slideNumber)
        {
            //build URI to get format scheme
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" + slideNumber + "/theme/formatScheme";

            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            FormatSchemeResponse formatSchemeResponse = JsonConvert.DeserializeObject<FormatSchemeResponse>(parsedJSON.ToString());
            FormatScheme formatscheme = formatSchemeResponse.FormatScheme;
        }

        /// <summary>
        /// Get format scheme from the specified slide of a presentation from a third party storage
        /// </summary>
        /// <param name="slideNumber"></param>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        /// <returns></returns>
        public FormatScheme GetFormatScheme(int slideNumber, StorageType storageType, string storageName)
        {
            //build URI to get format scheme
            StringBuilder strURI = new StringBuilder(Product.BaseProductUri + "/slides/" +
                FileName + "/slides/" + slideNumber + "/theme/formatScheme");

            switch (storageType)
            {
                case StorageType.AmazonS3:
                    strURI.Append("?storage=" + storageName);
                    break;
            }

            string signedURI = Utils.Sign(strURI.ToString());

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            FormatSchemeResponse formatSchemeResponse = JsonConvert.DeserializeObject<FormatSchemeResponse>(parsedJSON.ToString());
            return formatSchemeResponse.FormatScheme;

        }

        /// <summary>
        /// Get placeholder count from a particular slide
        /// </summary>
        /// <param name="slideNumber"></param>
        /// <returns></returns>
        public int GetPlaceholderCount(int slideNumber)
        {
            //build URI to get placeholder count
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" + slideNumber.ToString() + "/placeholders";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            PlaceholdersResponse PlaceholderResponse = JsonConvert.DeserializeObject<PlaceholdersResponse>(parsedJSON.ToString());
            return PlaceholderResponse.Placeholders.PlaceholderLinks.Count;
        }

        /// <summary>
        /// Get placeholder count in a slide from a 3rd party storage
        /// </summary>
        /// <param name="slideNumber"></param>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        /// <param name="folderName">In case of Amazon S3 storage the folder's path starts with Amazon S3 Bucket name.</param>
        /// <returns></returns>
        public int GetPlaceholderCount(int slideNumber, StorageType storageType, 
            string storageName, string folderName)
        {
            //build URI to get placeholder count
            StringBuilder strURI = new StringBuilder(Product.BaseProductUri + "/slides/" + FileName
               + "/slides/" + slideNumber.ToString() + "/placeholders" +
               (string.IsNullOrEmpty(folderName) ? "" : "?folder=" + folderName));

            switch (storageType)
            {
                case StorageType.AmazonS3:
                    strURI.Append("&storage=" + storageName);
                    break;
            }
            string signedURI = Utils.Sign(strURI.ToString());

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            PlaceholdersResponse PlaceholderResponse = JsonConvert.DeserializeObject<PlaceholdersResponse>(parsedJSON.ToString());
            return PlaceholderResponse.Placeholders.PlaceholderLinks.Count;
        }
        /// <summary>
        /// Get placeholder from a particular slide
        /// </summary>
        /// <param name="slideNumber"></param>
        /// <param name="PlaceholderIndex"></param>
        /// <returns></returns>
        public Placeholder GetPlaceholder(int slideNumber, int PlaceholderIndex)
        {
            //build URI to get placeholder
            string strURI = Product.BaseProductUri + "/slides/" + FileName + "/slides/" + slideNumber.ToString() + "/placeholders/" + PlaceholderIndex;
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            PlaceholderResponse PlaceholderResponse = JsonConvert.DeserializeObject<PlaceholderResponse>(parsedJSON.ToString());
            return PlaceholderResponse.Placeholder;
        }

        /// <summary>
        /// Get placeholder in a slide from a 3rd party storage
        /// </summary>
        /// <param name="slideNumber"></param>
        /// <param name="PlaceholderIndex"></param>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        /// <param name="folderName">In case of Amazon S3 storage the folder's path starts with Amazon S3 Bucket name.</param>
        /// <returns></returns>
        public Placeholder GetPlaceholder(int slideNumber, int PlaceholderIndex, 
            StorageType storageType, string storageName, string folderName)
        {
            //build URI to get placeholder
            StringBuilder strURI = new StringBuilder(Product.BaseProductUri + "/slides/" + FileName
                + "/slides/" + slideNumber.ToString() + "/placeholders/" + PlaceholderIndex +
                (string.IsNullOrEmpty(folderName) ? "" : "?folder=" + folderName));

            switch (storageType)
            {
                case StorageType.AmazonS3:
                    strURI.Append("&storage=" + storageName);
                    break;
            }
            string signedURI = Utils.Sign(strURI.ToString());

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            PlaceholderResponse PlaceholderResponse = JsonConvert.DeserializeObject<PlaceholderResponse>(parsedJSON.ToString());
            return PlaceholderResponse.Placeholder;
        }

    }
}
