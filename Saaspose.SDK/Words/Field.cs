﻿using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Common;
using Saaspose.Storage;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Saaspose.Words
{
    public class Field
    {
        public string Format { get; set; }
        public string Alignment { get; set; }
        public bool IsTop { get; set; }
        public bool SetPageNumberOnFirstPage { get; set; }

        /// <summary>
        /// insert page number filed into the document
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="alignment"></param>
        /// <param name="format"></param>
        /// <param name="isTop"></param>
        /// <param name="SetPageNumberOnFirstPage"></param>

        public Boolean insertPageNumber(string FileName, string alignment, string format, Boolean isTop, Boolean SetPageNumberOnFirstPage)
        {
            try
            {
                //build URI to get Image
                string strURI = Product.BaseProductUri + "/words/" + FileName + "/insertPageNumbers";
                
                string signedURI = Utils.Sign(strURI);

                //serialize the JSON request content
                Field field = new Field();
                field.Alignment = alignment;
                field.Format = format;
                field.IsTop = isTop;
                field.SetPageNumberOnFirstPage = SetPageNumberOnFirstPage;

                string strJSON = JsonConvert.SerializeObject(field);

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
                return false;
            }
        }

        /// <summary>
        /// Gets all merge filed names from document
        /// </summary>
        /// <param name="FileName"></param>
        public List<string> GetMailMergeFieldNames(string FileName)
        {
            try
            {
                //check whether file is set or not
                if (FileName == "")
                    throw new Exception("No file name specified");

                //build URI
                string strURI = Product.BaseProductUri + "/words/" + FileName;
                strURI += "/mailMergeFieldNames";

                //sign URI
                string signedURI = Utils.Sign(strURI);

                StreamReader reader = new StreamReader(Utils.ProcessCommand(signedURI, "GET"));

                //further process JSON response
                string strJSON = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);

                //Deserializes the JSON to a object. 
                MergeFieldResponse Response = JsonConvert.DeserializeObject<MergeFieldResponse>(parsedJSON.ToString());

                //return document property
                return Response.FieldNames.Names;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
