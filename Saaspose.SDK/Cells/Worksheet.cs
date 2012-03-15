using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Saaspose.Common;
using Saaspose.Storage;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Saaspose.Cells
{
    public class Worksheet
    {
        /// <summary>
        /// Worksheet Constructor, set the file name, password and worksheet name
        /// </summary>
        /// <param name="fileName"> File Name</param>
        public Worksheet(string fileName, string worksheetName)
        {
            FileName = fileName;
            WorkSheetName = worksheetName;

        }

        /// <summary>
        /// 
        /// </summary>
        public LinkResponse Link { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputFileName"></param>
        /// <param name="outputFormat"></param>
        /// <param name="saveLocation"></param>

        public void SaveAsImage(string outputFileName, ImageFormat outputFormat, SaveLocation saveLocation)
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
                strURI += "/worksheets/" + WorkSheetName + "?format=" + outputFormat;

                //sign URI
                string signedURI = Utils.Sign(strURI);

                //get response stream
                Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

                using (Stream fileStream = System.IO.File.OpenWrite(outputFileName))
                {
                    CopyStream(responseStream, fileStream);
                }
                responseStream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<LinkResponse> GetCellsList(int offset, int count)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/cells?offset=" + offset + "&count=" + count;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorksheetResponse worksheetResponse = JsonConvert.DeserializeObject<WorksheetResponse>(parsedJSON.ToString());

            return worksheetResponse.Cells.CellList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int GetMaxColumn(int offset, int count)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/cells?offset=" + offset + "&count=" + count;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorksheetResponse worksheetResponse = JsonConvert.DeserializeObject<WorksheetResponse>(parsedJSON.ToString());

            return worksheetResponse.Cells.MaxColumn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int GetMaxRow(int offset, int count)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/cells?offset=" + offset + "&count=" + count;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorksheetResponse worksheetResponse = JsonConvert.DeserializeObject<WorksheetResponse>(parsedJSON.ToString());

            return worksheetResponse.Cells.MaxRow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int GetCellsCount(int offset, int count)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/cells?offset=" + offset + "&count=" + count;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorksheetResponse worksheetResponse = JsonConvert.DeserializeObject<WorksheetResponse>(parsedJSON.ToString());

            return worksheetResponse.Cells.CellCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetAutoShapesCount()
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/autoshapes";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorksheetResponse worksheetResponse = JsonConvert.DeserializeObject<WorksheetResponse>(parsedJSON.ToString());

            return worksheetResponse.AutoShapes.AuotShapeList.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public AutoShape GetAutoShapeByIndex(int index)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/autoshapes/" + index;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            AutoShapesResponse autoShapesResponse = JsonConvert.DeserializeObject<AutoShapesResponse>(parsedJSON.ToString());

            return autoShapesResponse.AutoShape;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="outputFileName"></param>
        /// <param name="outputformat"></param>
        public void ConvertAutoShape(int index, string outputFileName, ImageFormat outputformat)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/autoshapes/" + index + "?format=" + outputformat;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            //get response stream
            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputFileName))
            {
                CopyStream(responseStream, fileStream);
            }
            responseStream.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public Cell GetCell(string cellName)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/cells/" + cellName;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            CellsResponse cellsResponse = JsonConvert.DeserializeObject<CellsResponse>(parsedJSON.ToString());

            return cellsResponse.Cell;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public Style GetCellStyle(string cellName)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/cells/" + cellName + "/style";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            CellsResponse cellsResponse = JsonConvert.DeserializeObject<CellsResponse>(parsedJSON.ToString());

            return cellsResponse.Style;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Chart GetChartByIndex(int index)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/charts/" + index;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            ChartsResponse autoShapesResponse = JsonConvert.DeserializeObject<ChartsResponse>(parsedJSON.ToString());

            return autoShapesResponse.Chart;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Hyperlink GetHyperlinkByIndex(int index)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/hyperlinks/" + index;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            HyperlinksResponse hyperlinksResponse = JsonConvert.DeserializeObject<HyperlinksResponse>(parsedJSON.ToString());

            return hyperlinksResponse.Hyperlink;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellName"></param>
        /// <returns></returns>
        public Comment GetComment(string cellName)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/comments/" + cellName;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            CommentsResponse commentResponse = JsonConvert.DeserializeObject<CommentsResponse>(parsedJSON.ToString());

            return commentResponse.Comment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="outputFileName"></param>
        /// <param name="outputformat"></param>
        public void ConvertChart(int index, string outputFileName, ImageFormat outputformat)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/charts/" + index + "?format=" + outputformat;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            //get response stream
            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputFileName))
            {
                CopyStream(responseStream, fileStream);
            }
            responseStream.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public OleObject GetOleObjectByIndex(int index)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/oleobjects/" + index;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            OleObjectsResponse oleObjectsResponse = JsonConvert.DeserializeObject<OleObjectsResponse>(parsedJSON.ToString());

            return oleObjectsResponse.OleObject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="outputFileName"></param>
        /// <param name="outputformat"></param>
        public void ConvertOleObject(int index, string outputFileName, ImageFormat outputformat)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/oleobjects/" + index + "?format=" + outputformat;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            //get response stream
            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputFileName))
            {
                CopyStream(responseStream, fileStream);
            }
            responseStream.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Picture GetPictureByIndex(int index)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/pictures/" + index;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            PicturesResponse picturesResponse = JsonConvert.DeserializeObject<PicturesResponse>(parsedJSON.ToString());

            return picturesResponse.Picture;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="outputFileName"></param>
        /// <param name="outputformat"></param>
        public void ConvertPicture(int index, string outputFileName, ImageFormat outputformat)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/pictures/" + index + "?format=" + outputformat;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            //get response stream
            Stream responseStream = Utils.ProcessCommand(signedURI, "GET");

            using (Stream fileStream = System.IO.File.OpenWrite(outputFileName))
            {
                CopyStream(responseStream, fileStream);
            }
            responseStream.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Validation GetValidationByIndex(int index)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/validations/" + index;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            ValidationsResponse validationsResponse = JsonConvert.DeserializeObject<ValidationsResponse>(parsedJSON.ToString());

            return validationsResponse.Validation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public MergedCell GetMergedCellByIndex(int index)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/mergedCells/" + index;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            MergedCellsResponse mergedCellsResponse = JsonConvert.DeserializeObject<MergedCellsResponse>(parsedJSON.ToString());

            return mergedCellsResponse.MergedCell;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetMergedCellsCount()
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/mergedCells";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorksheetResponse worksheetResponse = JsonConvert.DeserializeObject<WorksheetResponse>(parsedJSON.ToString());

            return worksheetResponse.MergedCells.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetValidationsCount()
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/validations";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorksheetResponse worksheetResponse = JsonConvert.DeserializeObject<WorksheetResponse>(parsedJSON.ToString());

            return worksheetResponse.Validations.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetPicturesCount()
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/pictures";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorksheetResponse worksheetResponse = JsonConvert.DeserializeObject<WorksheetResponse>(parsedJSON.ToString());

            return worksheetResponse.Pictures.PictureList.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetOleObjectsCount()
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/oleobjects";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorksheetResponse worksheetResponse = JsonConvert.DeserializeObject<WorksheetResponse>(parsedJSON.ToString());

            return worksheetResponse.OleObjects.OleOjectList.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetChartsCount()
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/charts";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorksheetResponse worksheetResponse = JsonConvert.DeserializeObject<WorksheetResponse>(parsedJSON.ToString());

            return worksheetResponse.Charts.ChartList.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetCommentsCount()
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/comments";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorksheetResponse worksheetResponse = JsonConvert.DeserializeObject<WorksheetResponse>(parsedJSON.ToString());

            return worksheetResponse.Comments.CommentList.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetHyperlinksCount()
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/hyperlinks";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorksheetResponse worksheetResponse = JsonConvert.DeserializeObject<WorksheetResponse>(parsedJSON.ToString());

            return worksheetResponse.Hyperlinks.Count;
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool HideWorksheet()
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/visible?isVisible=false";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "PUT"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorksheetResponse worksheetResponse = JsonConvert.DeserializeObject<WorksheetResponse>(parsedJSON.ToString());

            if (worksheetResponse.Status == "OK")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool UnhideWorksheet()
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/visible?isVisible=true";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "PUT"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorksheetResponse worksheetResponse = JsonConvert.DeserializeObject<WorksheetResponse>(parsedJSON.ToString());

            if (worksheetResponse.Status == "OK")
                return true;
            else
                return false;
        }

       
        public bool MoveWorksheet(string worksheetName, Position position)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/cells/" + FileName + "/worksheets/" +WorkSheetName+"/position";
                string signedURI = Utils.Sign(strURI);

                //serialize the JSON request content
                MoveWorksheet moveWorksheet = new MoveWorksheet();
                moveWorksheet.DestinationWorksheet = worksheetName;
                moveWorksheet.Position = position;

                string strJSON = JsonConvert.SerializeObject(moveWorksheet);

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
         

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formula"></param>
        /// <returns></returns>
        public string CalculateFormula(string formula)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/formulaResult?formula=" + formula;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            CalcualteFormulaResponse formulaResponse = JsonConvert.DeserializeObject<CalcualteFormulaResponse>(parsedJSON.ToString());

            return formulaResponse.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public List<TextItem> FindText(string text)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/findText?text=" + text;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "POST"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Create list of worksheets
            List<Saaspose.Cells.TextItem> textItems = new List<Saaspose.Cells.TextItem>();

            //Deserializes the JSON to a object. 
            WorkbookResponse docResponse = JsonConvert.DeserializeObject<WorkbookResponse>(parsedJSON.ToString());

            textItems = docResponse.TextItems.TextItemList;

            //return worksheets
            return textItems;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TextItem> GetTextItems()
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/" + WorkSheetName + "/textItems";

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Create list of worksheets
            List<Saaspose.Cells.TextItem> textItems = new List<Saaspose.Cells.TextItem>();

            //Deserializes the JSON to a object. 
            WorkbookResponse docResponse = JsonConvert.DeserializeObject<WorkbookResponse>(parsedJSON.ToString());

            textItems = docResponse.TextItems.TextItemList;

            //return worksheets
            return textItems;
        }

        /// <summary>
        /// Copies the contents of input to output. Doesn't close either stream.
        /// </summary>
        private static void CopyStream(Stream input, Stream output)
        {
            try
            {
                byte[] buffer = new byte[8 * 1024];
                int len;
                while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    output.Write(buffer, 0, len);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string WorkSheetName { get; set; }

        /// <summary>
        /// Workbook name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsGridLinesVisible { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsProtected { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

    }
}
