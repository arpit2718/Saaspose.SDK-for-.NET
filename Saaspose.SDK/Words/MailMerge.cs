using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Common;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.XPath;

namespace Saaspose.Words
{
    public class MailMerge
    {
        /// <summary>
        /// Execute mail merge without regions.
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="strXML"></param>
        /// <param name="saveformat"></param>
        /// <param name="output"></param>
        /// <param name="documentFolder"></param>
        /// <param name="deleteFromStorage"></param>

        public void ExecuteMailMerege(string FileName, string strXML, SaveFormat saveformat, string output,
            string documentFolder = "", bool deleteFromStorage = false)
        {
            try
            {
                //build URI to get Image
                string strURI = Product.BaseProductUri + "/words/" + FileName + "/executeMailMerge" +
                    (documentFolder == "" ? "" : "?folder=" + documentFolder);

                string signedURI = Utils.Sign(strURI);

                string outputFileName = null;

                using (Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strXML, "xml"))
                {
                    string strResponse = null;

                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        //further process JSON response
                        strResponse = reader.ReadToEnd();
                    }

                    using (MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(strResponse)))
                    {
                        XPathDocument xPathDoc = new XPathDocument(ms);
                        XPathNavigator navigator = xPathDoc.CreateNavigator();

                        //get File Name
                        XPathNodeIterator nodes = navigator.Select("/SaaSposeResponse/Document/FileName");
                        nodes.MoveNext();
                        outputFileName = nodes.Current.InnerXml;
                        //build URI
                        strURI = Product.BaseProductUri + "/words/" + outputFileName;
                        strURI += "?format=" + saveformat + (documentFolder == "" ? "" : "&folder=" + documentFolder);
                    }
                }
                //sign URI
                signedURI = Utils.Sign(strURI);

                //get response stream
                using (Stream responseStream = Utils.ProcessCommand(signedURI, "GET"))
                {

                    using (Stream fileStream = System.IO.File.OpenWrite(output))
                    {
                        Utils.CopyStream(responseStream, fileStream);
                    }
                }

                if (deleteFromStorage)
                {
                    signedURI = Utils.Sign(Product.BaseProductUri + "/storage/file/" +
                        (documentFolder == "" ? outputFileName : documentFolder + "/" + outputFileName));
                    Utils.ProcessCommand(signedURI, "DELETE");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Execute mail merge with regions.
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="strXML"></param>
        /// <param name="saveformat"></param>
        /// <param name="output"></param>
        /// <param name="documentFolder"></param>
        /// <param name="deleteFromStorage"></param>
        public void ExecuteMailMeregewithRegions(string FileName, string strXML, SaveFormat saveformat, string output,
            string documentFolder = "", bool deleteFromStorage = false)
        {
            try
            {
                //build URI to get Image
                string strURI = Product.BaseProductUri + "/words/" + FileName + "/executeMailMerge?withRegions=true" +
                    (documentFolder == "" ? "" : "&folder=" + documentFolder);

                string signedURI = Utils.Sign(strURI);

                string outputFileName = null;

                using (Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strXML, "xml"))
                {
                    string strResponse = null;

                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        //further process JSON response
                        strResponse = reader.ReadToEnd();
                    }

                    using (MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(strResponse)))
                    {
                        XPathDocument xPathDoc = new XPathDocument(ms);
                        XPathNavigator navigator = xPathDoc.CreateNavigator();

                        //get File Name
                        XPathNodeIterator nodes = navigator.Select("/SaaSposeResponse/Document/FileName");
                        nodes.MoveNext();
                        outputFileName = nodes.Current.InnerXml;
                        //build URI
                        strURI = Product.BaseProductUri + "/words/" + outputFileName;
                        strURI += "?format=" + saveformat + (documentFolder == "" ? "" : "&folder=" + documentFolder);
                    }
                }
                //sign URI
                signedURI = Utils.Sign(strURI);

                //get response stream
                using (Stream responseStream = Utils.ProcessCommand(signedURI, "GET"))
                {
                    using (Stream fileStream = System.IO.File.OpenWrite(output))
                    {
                        Utils.CopyStream(responseStream, fileStream);
                    }
                }

                if (deleteFromStorage)
                {
                    signedURI = Utils.Sign(Product.BaseProductUri + "/storage/file/" +
                        (documentFolder == "" ? outputFileName : documentFolder + "/" + outputFileName));
                    Utils.ProcessCommand(signedURI, "DELETE");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Execute mail merge template.
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="strXML"></param>
        /// <param name="saveformat"></param>
        /// <param name="output"></param>
        /// <param name="documentFolder"></param>
        /// <param name="deleteFromStorage"></param>
        public void ExecuteTemplate(string FileName, string strXML, SaveFormat saveformat, string output,
            string documentFolder = "", bool deleteFromStorage = false)
        {
            try
            {
                //build URI to get Image
                string strURI = Product.BaseProductUri + "/words/" + FileName + "/executeTemplate" +
                    (documentFolder == "" ? "" : "?folder=" + documentFolder);

                string signedURI = Utils.Sign(strURI);

                string outputFileName = null;

                using (Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strXML, "xml"))
                {
                    string strResponse = null;

                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        //further process JSON response
                        strResponse = reader.ReadToEnd();
                    }

                    using (MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(strResponse)))
                    {
                        XPathDocument xPathDoc = new XPathDocument(ms);
                        XPathNavigator navigator = xPathDoc.CreateNavigator();

                        //get File Name
                        XPathNodeIterator nodes = navigator.Select("/SaaSposeResponse/Document/FileName");
                        nodes.MoveNext();
                        outputFileName = nodes.Current.InnerXml;
                        //build URI
                        strURI = Product.BaseProductUri + "/words/" + outputFileName;
                        strURI += "?format=" + saveformat + (documentFolder == "" ? "" : "&folder=" + documentFolder);
                    }
                }
                //sign URI
                signedURI = Utils.Sign(strURI);

                //get response stream
                using (Stream responseStream = Utils.ProcessCommand(signedURI, "GET"))
                {
                    using (Stream fileStream = System.IO.File.OpenWrite(output))
                    {
                        Utils.CopyStream(responseStream, fileStream);
                    }
                }

                if (deleteFromStorage)
                {
                    signedURI = Utils.Sign(Product.BaseProductUri + "/storage/file/" +
                        (documentFolder == "" ? outputFileName : documentFolder + "/" + outputFileName));
                    Utils.ProcessCommand(signedURI, "DELETE");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
