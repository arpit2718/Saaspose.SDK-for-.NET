using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Common;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Saaspose.Storage;

namespace Saaspose.BarCode
{
    /// <summary>
    /// Class to read barcodes from image. There are 2 ways to feed the image for barcode recognition
    /// 1. Image from Saaspose server.
    /// 2. Image from any URL.
    /// 3. Local image. Image will be uploaded on Saaspose server in this case.
    /// </summary>
    public class BarCodeReader
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public BarCodeReader()
        {

        }

        // Declare private member variables to be used within different methods
        private string _remoteImageName = "";

        /// <summary>
        /// Read barcode from local image. Local image will first be uploaded on Saaspose server
        /// and then recognized using Saaspose.BarCode. Result will be returned to client
        /// </summary>
        /// <param name="localImage">Full path and file name of local image</param>
        /// <param name="remoteFolder">Remote folder name on Saaspose storage</param>
        /// <param name="barcodeReadType">Barcode type to be recognized</param>
        /// <returns>List of recognized barcodes</returns>
        /// <example>
        /// BarCodeReader reader = new BarCodeReader();
        /// List<RecognizedBarCode> barcodesRead = reader.ReadFromLocalImage(@"c:\pdf417.jpg", "", BarCodeReadType.Pdf417);
        /// foreach (RecognizedBarCode barcodeRead in barcodesRead)
        /// {
        ///     Console.WriteLine("Codetext: " + barcodeRead.BarCodeValue + "\nType: " + barcodeRead.BarCodeType);
        /// }
        /// </example>
        public List<RecognizedBarCode> ReadFromLocalImage(string localImage, string remoteFolder, BarCodeReadType barcodeReadType)
        {
            // First upload the local image to remote location
            Folder folder = new Folder();
            folder.UploadFile(localImage, remoteFolder);

            // After upload, perform server recognition on uploaded image
            return Read(Path.GetFileName(localImage), remoteFolder, barcodeReadType);
        }
        
        /// <summary>
        /// Read barcode from image on Saaspose server.
        /// </summary>
        /// <param name="remoteImageName">Remote image file name.</param>
        /// <param name="remoteFolder">Optional. Specify folder path to locate the image.</param>
        /// <param name="readType">Barcode type</param>
        /// <returns>List of recognized barcodes</returns>
        /// <example>
        /// BarCodeReader reader = new BarCodeReader();
        /// List<RecognizedBarCode> barcodesRead = reader.Read("test-1234.png", "", BarCodeReadType.AllSupportedTypes);
        /// Console.WriteLine("Read from server.");
        /// foreach (RecognizedBarCode barcodeRead in barcodesRead)
        /// {
        ///     Console.WriteLine("Codetext: " + barcodeRead.BarCodeValue + "\nType: " + barcodeRead.BarCodeType);
        /// }
        /// </example>
        public List<RecognizedBarCode> Read(string remoteImageName, string remoteFolder, BarCodeReadType readType)
        {
            _remoteImageName = remoteImageName;

            PerformValidations(false);

            // Build URL with querystring request parameters
            string uri = UriBuilder(remoteImageName, remoteFolder, readType);

            // Send the request to Saaspose server
            Stream responseStream = Utils.ProcessCommand(Utils.Sign(uri), "GET");
            StreamReader reader = new StreamReader(responseStream);
            // Read the response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            RecognitionResponse barcodeRecognitionResponse = JsonConvert.DeserializeObject<RecognitionResponse>(parsedJSON.ToString());

            return barcodeRecognitionResponse.Barcodes;
        }

        /// <summary>
        /// Read barcode from URL
        /// </summary>
        /// <param name="url">A URL containing image e.g. http://www.yourdomain.com/folder/images/code39.png </param>
        /// <param name="readType">type of barcode to be recognized</param>
        /// <returns>The response from Saaspose service</returns>
        /// <example>
        /// BarCodeReader reader = new BarCodeReader();
        /// List<RecognizedBarCode> barcodesRead = serverReader.Read("http://upload.wikimedia.org/wikipedia/commons/c/ce/WikiQRCode.png", BarCodeReadType.AllSupportedTypes);
        /// Console.WriteLine("Read from URL.");
        /// foreach (RecognizedBarCode barcodeRead in barcodesRead)
        /// {
        ///     Console.WriteLine("Codetext: " + barcodeRead.BarCodeValue + "\nType: " + barcodeRead.BarCodeType);
        /// }
        /// </example>
        public List<RecognizedBarCode> Read(string url, BarCodeReadType readType)
        {
            // Only validate the API keys
            PerformValidations(true);

            // Build URI for accessing Saaspose.BarCode API
            string uri = UriBuilderForURLImage(url, readType);

            // Send the request to Saaspose server
            Stream responseStream = Utils.ProcessCommand(Utils.Sign(uri), "POST");
            StreamReader reader = new StreamReader(responseStream);
            // Read the response
            string strJSON = reader.ReadToEnd();

            //Parse the json string to JObject
            JObject parsedJSON = JObject.Parse(strJSON);


            //Deserializes the JSON to a object. 
            RecognitionResponse barcodeRecognitionResponse = JsonConvert.DeserializeObject<RecognitionResponse>(parsedJSON.ToString());

            return barcodeRecognitionResponse.Barcodes;
        }

        private string UriBuilder(string remoteImage, string remoteFolder, BarCodeReadType readType)
        {
            // Initialize with server URI, text and type, which are must
            string uri = Saaspose.Common.Product.BaseProductUri + "/barcode/";
            // remoteImage is the name of image on Saaspose server
            if (remoteImage != null && remoteImage.Trim().Length > 0)
                uri += remoteImage + "/";
            uri += "recognize?";

            // First parameter. Add barcode type to be recognized
            // If AllSupportedTypes is selected, set blank, otherwise, send the ToString()
            if (readType == BarCodeReadType.AllSupportedTypes)
                uri += "type=";
            else
                uri += "type=" + readType.ToString();

            // Add remote folder parameter
            if (remoteFolder != null && remoteFolder.Trim().Length > 0)
                uri += "&format=" + remoteFolder;

            // Add folder parameter
            if (remoteFolder != null && remoteFolder.Trim().Length > 0)
                uri += "&folder=" + remoteFolder;

            // return the URI
            return uri;
        }

        private void PerformValidations(bool apikeysOnly)
        {
            // Throw exception if App Key is empty
            if (SaasposeApp.AppKey == null || SaasposeApp.AppKey.Trim().Length == 0)
                throw new Exception("App Key is not specified. Please set the App Key property.");

            // Throw exception if App SID is empty
            if (SaasposeApp.AppSID == null || SaasposeApp.AppSID.Trim().Length == 0)
                throw new Exception("App SID is not specified. Please set App SID property.");

            // If only API keys need to be validated, then no need to proceed further, so return
            if (apikeysOnly == true)
                return;

            // Throw exception if barcode value is empty
            if (_remoteImageName == null || _remoteImageName.Trim().Length == 0)
                throw new Exception("Image name is not specified.");
        }

        /// <summary>
        /// Build URI for the recognition of image from URL
        /// </summary>
        /// <param name="url">URL of the image</param>
        /// <param name="readType">barcode read type</param>
        /// <returns>URI of Saaspose URL image recognition</returns>
        private string UriBuilderForURLImage(string url, BarCodeReadType readType)
        {
            // Initialize with server URI, text and type, which are must
            string uri = Saaspose.Common.Product.BaseProductUri + "/barcode/";
            uri += "recognize?";

            // First parameter. Add barcode type to be recognized
            // If AllSupportedTypes is selected, set blank, otherwise, send the ToString()
            if (readType == BarCodeReadType.AllSupportedTypes)
                uri += "type=";
            else
                uri += "type=" + readType.ToString();

            // Add URL parameter
            if (url != null && url.Trim().Length > 0)
                uri += "&url=" + url;

            // return the URI
            return uri;
        }
    }
}
