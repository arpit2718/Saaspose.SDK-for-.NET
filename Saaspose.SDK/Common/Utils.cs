using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Common;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Saaspose.Common
{
    /// <summary>
    /// Provides common untility methods.
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Method to Sign your app key
        /// This should be called with each URI resource
        /// before sending any HTTP command to the remote server
        /// </summary>
        /// <param name="url"></param>
        /// <param name="app"></param>
        /// <returns></returns>
        public static string Sign(string url)
        {
            try
            {
                // Add appSID parameter.
                UriBuilder builder = new UriBuilder(url);
                if (builder.Query != null && builder.Query.Length > 1)
                    builder.Query = builder.Query.Substring(1) + "&appSID=" + SaasposeApp.AppSID;
                else
                    builder.Query = "appSID=" + SaasposeApp.AppSID;
                // Remove final slash here as it can be added automatically.
                builder.Path = builder.Path.TrimEnd('/');
                // Compute the hash.

                byte[] privateKey = System.Text.Encoding.UTF8.GetBytes(SaasposeApp.AppKey);

                System.Security.Cryptography.HMACSHA1 algorithm = new System.Security.Cryptography.HMACSHA1(privateKey);
                //System.Text.ASCIIEncoding
                byte[] sequence = System.Text.ASCIIEncoding.ASCII.GetBytes(builder.Uri.AbsoluteUri);
                byte[] hash = algorithm.ComputeHash(sequence);
                string signature = Convert.ToBase64String(hash);
                // Remove invalid symbols.
                signature = signature.TrimEnd('=');
                signature = System.Web.HttpUtility.UrlEncode(signature);
                // Convert codes to upper case as they can be updated automatically.
                signature = System.Text.RegularExpressions.Regex.Replace(signature, "%[0-9a-f]{2}", e => e.Value.ToUpper());
                //signature = System.Text.RegularExpressions.Regex.Replace(signature, "%[0-9a-f]{2}", delegate(string e){ e.Value.ToUpper()});
                // Add the signature to query string.
                return string.Format("{0}&signature={1}", builder.Uri.AbsoluteUri, signature);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// This method can be used with all the Http GET, PUT, POST and DELETE commands
        /// supported by the resource. Returns response in XML format as string.
        /// </summary>
        /// <param name="strURI"></param>
        /// <param name="strHttpCommand"></param>
        /// <returns></returns>
        public static Stream ProcessCommand(string strURI, string strHttpCommand)
        {
            try
            {
                Uri address = new Uri(strURI);
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(address);
                request.Method = strHttpCommand;
                //if(strHttpCommand == "POST")
                //request.ContentType = "application/xml";
                //else
                request.ContentType = "application/json";

                request.ContentLength = 0;
                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                return response.GetResponseStream();
            }
            catch (System.Net.WebException webex)
            {
                throw new Exception(webex.Message);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }


        public static Stream ProcessCommand(string strURI, string strHttpCommand, string strContent)
        {
            try
            {
                byte[] arr = System.Text.Encoding.UTF8.GetBytes(strContent);

                Uri address = new Uri(strURI);
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(address);
                request.Method = strHttpCommand;
                request.ContentType = "application/json";

                request.ContentLength = arr.Length;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(arr, 0, arr.Length);
                dataStream.Close();

                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                return response.GetResponseStream();
            }
            catch (System.Net.WebException webex)
            {
                throw new Exception(webex.Message);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        public static Stream ProcessCommand(string strURI, string strHttpCommand, Stream streamContent)
        {
            try
            {
               
                Uri address = new Uri(strURI);

                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(address);
                
                request.Method = strHttpCommand;
                
                request.ContentType = "application/json";

                request.ContentLength = streamContent.Length;

                Stream reqStream = request.GetRequestStream();

                byte[] inData = new byte[streamContent.Length];

                int bytesRead = streamContent.Read(inData, 0, (int)streamContent.Length);

                reqStream.Write(inData, 0, (int)streamContent.Length);
                
                streamContent.Close();

                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
               
                reqStream.Close();  

                return response.GetResponseStream();
            }
            catch (System.Net.WebException webex)
            {
                throw new Exception(webex.Message);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
        public static Stream ProcessCommand(string strURI, string strHttpCommand, string strContent, string ContentType = "xml")
        {
            try
            {
                byte[] arr = System.Text.Encoding.UTF8.GetBytes(strContent);

                Uri address = new Uri(strURI);
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(address);
                request.Method = strHttpCommand;
                if (ContentType.ToLower() == "xml")
                    request.ContentType = "application/xml";
                else
                    request.ContentType = "application/json";

                request.ContentLength = arr.Length;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(arr, 0, arr.Length);
                dataStream.Close();

                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                return response.GetResponseStream();
            }
            catch (System.Net.WebException webex)
            {
                throw new Exception(webex.Message);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
        /// <summary>
        /// This method can be used to upload binary files to the remote URI using
        /// Http PUT or POST commands
        /// </summary>
        /// <param name="localFile"></param>
        /// <param name="uploadUrl"></param>
        /// <param name="strHttpCommand"></param>
        /// <returns></returns>
        public static string UploadFileBinary(string localFile, string uploadUrl, string strHttpCommand)
        {
            try
            {
                System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uploadUrl);

                req.Method = strHttpCommand;
                req.ContentType = "application/x-www-form-urlencoded";
                

                req.AllowWriteStreamBuffering = true;

                // Retrieve request stream 
                System.IO.Stream reqStream = req.GetRequestStream();

                // Open the local file
                System.IO.FileStream rdr = new System.IO.FileStream(localFile, System.IO.FileMode.Open);

                // Allocate byte buffer to hold file contents
                byte[] inData = new byte[4096];

                // loop through the local file reading each data block
                //  and writing to the request stream buffer
                int bytesRead = rdr.Read(inData, 0, inData.Length);
                while (bytesRead > 0)
                {
                    reqStream.Write(inData, 0, bytesRead);
                    bytesRead = rdr.Read(inData, 0, inData.Length);
                }

                rdr.Close();
                reqStream.Close();

                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)req.GetResponse();
                return response.StatusCode.ToString();
            }
            catch (System.Net.WebException webex)
            {
                throw new Exception(webex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        
        /// <summary>
        /// This method parses XML for a particular non recursive XML field and returns value of the field.
        /// </summary>
        /// <param name="strXML"></param>
        /// <param name="strFieldName"></param>
        /// <returns></returns>
        public static string GetFieldValue(string strJSON, string strFieldName)
        {
            try
            {
                //JObject parsedJSON = JObject.Parse(strJSON);

                //long totalSize = (long)parsedJSON["DiscUsage"]["TotalSize"];
                //long usedSize = (long)parsedJSON["DiscUsage"]["UsedSize"];

                //return doc.GetElementsByTagName(strFieldName)[0].InnerText;



                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This method parses XML for a count of a particular field.
        /// </summary>
        /// <param name="strXML"></param>
        /// <param name="strFieldName"></param>
        /// <returns></returns>
        public static int GetFieldCount(string strJSON, string strFieldName)
        {
            try
            {
                //System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                //System.IO.MemoryStream ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(strXML));
                //System.IO.StreamReader reader = new System.IO.StreamReader(ms);

                //doc.Load(reader);
                //return doc.GetElementsByTagName(strFieldName).Count;

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Copies the contents of input to output. Doesn't close either stream.
        /// </summary>
        public static void CopyStream(Stream input, Stream output)
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

    }
}
