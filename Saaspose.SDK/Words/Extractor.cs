using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Saaspose.Common;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Saaspose.Words
{
    public class Extractor
    {
        public Extractor() { }

        public List<Paragraph> GetText(string FileName)
        {
            try
            {
                //build URI
                string strURI = Product.BaseProductUri + "/words/" + FileName;
                strURI += "/textItems";

                //sign URI
                string signedURI = Utils.Sign(strURI);

                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));
                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //List of text items in document
                List<Saaspose.Words.Paragraph> paragraphs = new List<Saaspose.Words.Paragraph>();

                //Deserializes the JSON to a object. 
                DocumentTextResponse docResponse = JsonConvert.DeserializeObject<DocumentTextResponse>(parsedJSON.ToString());

                paragraphs = docResponse.TextItems.List;

                return paragraphs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Gets all Drawing Objects from document
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="outputPath"></param>
        /// <returns></returns>
        public void GetDrawingObjects(string FileName, string outputPath)
        {
            //build URI to get Drawing Objects
            string strURI = Product.BaseProductUri + "/words/" + FileName + "/drawingObjects";
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            StreamReader reader = new StreamReader(responseStream);
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            DrawingObjectsResponse Response = JsonConvert.DeserializeObject<DrawingObjectsResponse>(parsedJSON.ToString());

            int i = 1;
            foreach (Saaspose.Words.List list in Response.DrawingObjects.List)
            {
                GetDrawingObject(list.link.Href, outputPath);
                i++;
            }
        }

        /// <summary>
        /// Get the drawing object from document
        /// </summary>
        /// <param name="strURI"></param>
        /// <param name="outputPath">C:\Output.jpg</param>
        public void GetDrawingObject(string strURI, string outputPath)
        {

            try
            {
                //build URI to get Drawing Objects
                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                StreamReader reader = new StreamReader(responseStream);
                
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Deserializes the JSON to a object. 
                DrawingObjectsResponse Response = JsonConvert.DeserializeObject<DrawingObjectsResponse>(parsedJSON.ToString());

                string index = Response.DrawingObject.link.Href.Substring(Response.DrawingObject.link.Href.LastIndexOf("/") + 1).ToString();

                if (Response.DrawingObject.ImageDataLink != null && Response.DrawingObject.OleDataLink == null)
                {
                    //build URI to get Image
                    strURI = strURI + "/imageData";//?format=" + DrawingObjectsRenderFormat.jpeg;
                    outputPath = outputPath + "\\DrawingObject_" + index + "." + DrawingObjectsRenderFormat.jpeg;
                }
                else if (Response.DrawingObject.OleDataLink != null)
                {
                    //build URI to get OLE
                    strURI = strURI + "/oleData";//format=" + DrawingObjectsRenderFormat.jpeg;
                    outputPath = outputPath + "\\DrawingObject__" + index + ".xlsx"; // This needs to be discuss
                }
                else
                {
                    //build URI to get Image
                    strURI = strURI + "?format=" + DrawingObjectsRenderFormat.jpeg;
                    outputPath = outputPath + "\\DrawingObject__" + index + "." + DrawingObjectsRenderFormat.jpeg;
                }

                signedURI = Utils.Sign(strURI);

                responseStream = Utils.ProcessCommand(signedURI, "GET");

                using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
                {
                    Utils.CopyStream(responseStream, fileStream);
                }
                responseStream.Close();
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// Get the List of drawing object from document
        /// </summary>
        /// <param name="FileName"></param>
        public Dictionary<int, string> GetDrawingObjectList(string FileName)
        {

            try
            {
                //build URI to get Drawing Objects
                string strURI = Product.BaseProductUri + "/words/" + FileName + "/drawingObjects";
                
                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                StreamReader reader = new StreamReader(responseStream);
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Deserializes the JSON to a object. 
                DrawingObjectsResponse Response = JsonConvert.DeserializeObject<DrawingObjectsResponse>(parsedJSON.ToString());

                int index = 0;
                Dictionary<int, string> dObject = new Dictionary<int, string>();

                foreach (Saaspose.Words.List list in Response.DrawingObjects.List)
                {
                    responseStream = Utils.ProcessCommand(Utils.Sign(list.link.Href), "GET");
                    reader = new StreamReader(responseStream);
                    strJSON = reader.ReadToEnd();
                    parsedJSON = JObject.Parse(strJSON);

                    //Deserializes the JSON to a object. 
                    Response = JsonConvert.DeserializeObject<DrawingObjectsResponse>(parsedJSON.ToString());

                    if (Response.DrawingObject.ImageDataLink != null && Response.DrawingObject.OleDataLink == null)
                    {
                        dObject.Add(index, Response.DrawingObject.ImageDataLink.Href);
                        index++;
                    }
                    else if (Response.DrawingObject.OleDataLink != null)
                    {
                        dObject.Add(index, Response.DrawingObject.OleDataLink.Href);
                        index++;
                    }
                    else
                    {
                        dObject.Add(index, Response.DrawingObject.RenderLinks[0].Href);
                        index++;
                    }
                }

                responseStream.Close();
                return dObject;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get the OLE drawing object from document
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="index"></param>
        /// <param name="renderformat"></param>
        /// <param name="outputPath"></param>
        public void GetoleData(string FileName, int index, DrawingObjectsRenderFormat renderformat, string outputPath)
        {
            //build URI to get Image
            string strURI = Product.BaseProductUri + "/words/" + FileName + "/drawingObjects/" + index + "/oleData";

            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
            {
                Utils.CopyStream(responseStream, fileStream);
            }
            responseStream.Close();
        }


        /// <summary>
        /// Get the Image drawing object from document
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="index"></param>
        /// <param name="renderformat"></param>
        /// <param name="outputPath"></param>
        public void GetimageData(string FileName, int index, DrawingObjectsRenderFormat renderformat, string outputPath)
        {
            //build URI to get Image
            string strURI = Product.BaseProductUri + "/words/" + FileName + "/drawingObjects/" + index + "/ImageData";

            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputPath))
            {
                Utils.CopyStream(responseStream, fileStream);
            }
            responseStream.Close();
        }

        /// <summary>
        /// Convert drawing object to image
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="index"></param>
        /// <param name="renderformat"></param>
        /// <param name="outputPath"></param>
        public void ConvertDrawingObject(string FileName, int index, DrawingObjectsRenderFormat renderformat, string outputPath)
        {
            //build URI to get Image
            string strURI = Product.BaseProductUri + "/words/" + FileName + "/drawingObjects/" + index;
            strURI = strURI + "?format=" + renderformat.ToString();

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
