using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Common;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Saaspose.Words
{
    public class DocumentBuilder
    {
        public class WatermarkText
        {
            public string Text { get; set; }
            public double RotationAngle { get; set; }
        }

        public class WatermarkImage
        {
            public string imageFile { get; set; }
            public double RotationAngle { get; set; }
        }

        public class ReplaceText
        {
            public string OldValue { get; set; }
            public string NewValue { get; set; }
            public bool IsMatchCase { get; set; }
            public bool IsMatchWholeWord { get; set; }
        }

        /// <summary>
        /// insert water mark text into the document
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="text"></param>
        /// <param name="rotationAngle"></param>
        /// <returns></returns>
        public Boolean insertWatermarkText(string FileName, string text, double rotationAngle)
        {
            try
            {
                //build URI to get Image
                string strURI = Product.BaseProductUri + "/words/" + FileName + "/insertWatermarkText";

                string signedURI = Utils.Sign(strURI);

                //serialize the JSON request content
                WatermarkText watermark = new WatermarkText();
                watermark.Text = text;
                watermark.RotationAngle = rotationAngle;

                string strJSON = JsonConvert.SerializeObject(watermark);

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
        /// insert image water mark into the document
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="imageFile"></param>
        /// <param name="rotationAngle"></param>
        /// <returns></returns>
        public Boolean insertWatermarkImage(string FileName, string imageFile, double rotationAngle)
        {
            try
            {
                //build URI to get Image
                string strURI = Product.BaseProductUri + "/words/" + FileName + "/insertWatermarkImage?imageFile=";
                strURI += imageFile + "&rotationAngle=" + rotationAngle;

                string signedURI = Utils.Sign(strURI);

                ////serialize the JSON request content
                //WatermarkImage watermark = new WatermarkImage();
                //watermark.imageFile = imageFile;
                //watermark.RotationAngle = rotationAngle;

                //string strJSON = JsonConvert.SerializeObject(watermark);

                Stream responseStream = Utils.ProcessCommand(signedURI, "POST");
                //Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strJSON);

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
        /// Replace a text with new value into the document
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="OldValue"></param>
        /// <param name="NewValue"></param>
        /// <param name="IsMatchCase"></param>
        /// <param name="IsMatchWholeWord"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public void replaceText(string FileName, string OldValue, string NewValue, bool IsMatchCase, bool IsMatchWholeWord, string output)
        {
            try
            {
                //build URI to get Image
                string strURI = Product.BaseProductUri + "/words/" + FileName + "/replaceText";

                string signedURI = Utils.Sign(strURI);

                //serialize the JSON request content
                ReplaceText repacetext = new ReplaceText();
                repacetext.OldValue = OldValue;
                repacetext.NewValue = NewValue;
                repacetext.IsMatchCase = IsMatchCase;
                repacetext.IsMatchWholeWord = IsMatchWholeWord;

                string strJSON = JsonConvert.SerializeObject(repacetext);

                Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strJSON);

                StreamReader reader = new StreamReader(responseStream);
                string strResponse = reader.ReadToEnd();

                //Parse the json string to JObject
                JObject pJSON = JObject.Parse(strResponse);

                ReplaceTextResponse baseResponse = JsonConvert.DeserializeObject<ReplaceTextResponse>(pJSON.ToString());

                //sign URI
                signedURI = Utils.Sign(baseResponse.DocumentLink.Href + "?format=doc");

                //get response stream
                responseStream = Utils.ProcessCommand(signedURI, "GET");

                using (Stream fileStream = System.IO.File.OpenWrite(output))
                {
                    Utils.CopyStream(responseStream, fileStream);
                }
                responseStream.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
