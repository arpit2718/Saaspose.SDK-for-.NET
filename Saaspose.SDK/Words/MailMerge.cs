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

        public void ExecuteMailMerege(string FileName, string strXML, SaveFormat saveformat, string output, string documentFolder = "")
        {
            try
            {
                //build URI to get Image
                string strURI = Product.BaseProductUri + "/words/" + FileName + "/executeMailMerge" +
                    (documentFolder == "" ? "" : "?folder=" + documentFolder);

                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strXML, "xml");

                StreamReader reader = new StreamReader(responseStream);

                //further process JSON response
                string strResponse = reader.ReadToEnd();

                MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(strResponse));
                XPathDocument xPathDoc = new XPathDocument(ms);
                XPathNavigator navigator = xPathDoc.CreateNavigator();

                //get File Name
                XPathNodeIterator nodes = navigator.Select("/SaaSposeResponse/Document/FileName");
                nodes.MoveNext();

                //build URI
                strURI = Product.BaseProductUri + "/words/" + nodes.Current.InnerXml;
                strURI += "?format=" + saveformat + (documentFolder == "" ? "" : "&folder=" + documentFolder);

                //sign URI
                signedURI = Utils.Sign(strURI);

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

        /// <summary>
        /// Execute mail merge with regions.
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="strXML"></param>
        /// <param name="saveformat"></param>
        /// <param name="output"></param>
        public void ExecuteMailMeregewithRegions(string FileName, string strXML, SaveFormat saveformat, string output, string documentFolder = "")
        {
            try
            {
                //build URI to get Image
                string strURI = Product.BaseProductUri + "/words/" + FileName + "/executeMailMerge?withRegions=true" +
                    (documentFolder == "" ? "" : "&folder=" + documentFolder);

                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strXML, "xml");

                StreamReader reader = new StreamReader(responseStream);

                //further process JSON response
                string strResponse = reader.ReadToEnd();

                MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(strResponse));
                XPathDocument xPathDoc = new XPathDocument(ms);
                XPathNavigator navigator = xPathDoc.CreateNavigator();

                //get File Name
                XPathNodeIterator nodes = navigator.Select("/SaaSposeResponse/Document/FileName");
                nodes.MoveNext();

                //build URI
                strURI = Product.BaseProductUri + "/words/" + nodes.Current.InnerXml;
                strURI += "?format=" + saveformat + (documentFolder == "" ? "" : "&folder=" + documentFolder);

                //sign URI
                signedURI = Utils.Sign(strURI);

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

        /// <summary>
        /// Execute mail merge template.
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="strXML"></param>
        /// <param name="saveformat"></param>
        /// <param name="output"></param>
        public void ExecuteTemplate(string FileName, string strXML, SaveFormat saveformat, string output, string documentFolder = "")
        {
            try
            {
                //build URI to get Image
                string strURI = Product.BaseProductUri + "/words/" + FileName + "/executeTemplate" +
                    (documentFolder == "" ? "" : "?folder=" + documentFolder);

                string signedURI = Utils.Sign(strURI);

                Stream responseStream = Utils.ProcessCommand(signedURI, "POST", strXML, "xml");

                StreamReader reader = new StreamReader(responseStream);

                //further process JSON response
                string strResponse = reader.ReadToEnd();

                MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(strResponse));
                XPathDocument xPathDoc = new XPathDocument(ms);
                XPathNavigator navigator = xPathDoc.CreateNavigator();

                //get File Name
                XPathNodeIterator nodes = navigator.Select("/SaaSposeResponse/Document/FileName");
                nodes.MoveNext();

                //build URI
                strURI = Product.BaseProductUri + "/words/" + nodes.Current.InnerXml;
                strURI += "?format=" + saveformat + (documentFolder == "" ? "" : "&folder=" + documentFolder);

                //sign URI
                signedURI = Utils.Sign(strURI);

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
