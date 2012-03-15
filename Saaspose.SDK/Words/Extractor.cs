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
    }
}
