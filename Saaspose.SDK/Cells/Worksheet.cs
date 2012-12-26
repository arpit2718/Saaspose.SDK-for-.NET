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

        public List<LinkResponse> GetRowsList(int offset, int count)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/cells/rows?offset=" + offset + "&count=" + count;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorksheetResponse worksheetResponse = JsonConvert.DeserializeObject<WorksheetResponse>(parsedJSON.ToString());

            return worksheetResponse.Rows.RowsList;
        }

        public List<LinkResponse> GetColumnsList(int offset, int count)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/cells/columns?offset=" + offset + "&count=" + count;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorksheetResponse worksheetResponse = JsonConvert.DeserializeObject<WorksheetResponse>(parsedJSON.ToString());

            return worksheetResponse.Columns.ColumnsList;
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
       /// <param name="cellName"></param>
       /// <param name="style"></param>
       /// <returns></returns>
        public Style SetCellStyle(string cellName, Style style)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/cells/" + cellName + "/style";

            string strJSON = JsonConvert.SerializeObject(style);

            //sign URI
            string signedURI = Utils.Sign(strURI);

            Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strJSON);

            StreamReader reader = new StreamReader(responseStream);

            //further process JSON response
            string strResponse = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strResponse);

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
 

        public void SetCellValue(string cellName, string valueType, string value)
        {
            try
            {
                //build URI to get page count
                string strURI = Product.BaseProductUri + "/cells/" + FileName;
                strURI += "/worksheets/" + WorkSheetName + "/cells/" +cellName +"?value="+value+"&type="+valueType;


                string signedURI = Utils.Sign(strURI);               

                Stream responseStream = Utils.ProcessCommand(signedURI, "POST");

                StreamReader reader = new StreamReader(responseStream);
                string strResponse = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject pJSON = JObject.Parse(strResponse);

                BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(pJSON.ToString());

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
        public int GetRowsCount(int offset, int count)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/cells/rows?offset=" + offset + "&count=" + count;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            WorksheetResponse worksheetResponse = JsonConvert.DeserializeObject<WorksheetResponse>(parsedJSON.ToString());

            return worksheetResponse.Rows.RowCount;
        }

        public Row GetRow(int rowIndex)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/cells/rows/" + rowIndex;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            RowsResponse rowsResponse = JsonConvert.DeserializeObject<RowsResponse>(parsedJSON.ToString());

            return rowsResponse.Row;
        }

        public bool DeleteRow(int rowIndex)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/cells/rows/" + rowIndex;

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

        public bool SortData(DataSort dataSort, string cellArea)
        {
            try
            {
                //build URI
                string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
                strURI += "/worksheets/" + WorkSheetName + "/sort?" + cellArea;

                string signedURI = Utils.Sign(strURI);
                
                string strJSON = JsonConvert.SerializeObject(dataSort);

                Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strJSON);

                StreamReader reader = new StreamReader(responseStream);
                string strResponse = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject pJSON = JObject.Parse(strResponse);

                BaseResponse baseResponse = JsonConvert.DeserializeObject<BaseResponse>(pJSON.ToString());

                if (baseResponse.Status == "OK")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Column GetColumn(int columnIndex)
        {
            //check whether file is set or not
            if (FileName == "")
                throw new Exception("No file name specified");

            //build URI
            string strURI = Saaspose.Common.Product.BaseProductUri + "/cells/" + FileName;
            strURI += "/worksheets/" + WorkSheetName + "/columns/" + columnIndex;

            //sign URI
            string signedURI = Utils.Sign(strURI);

            StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

            //further process JSON response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);

            //Deserializes the JSON to a object. 
            ColumnsResponse columnsResponse = JsonConvert.DeserializeObject<ColumnsResponse>(parsedJSON.ToString());

            return columnsResponse.Column;
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
