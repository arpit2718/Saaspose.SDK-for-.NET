using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Common;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Saaspose.BarCode
{
    /// <summary>
    /// Class to create barcodes.
    /// </summary>
    /// <example>
    /// Create a Code128 barcode and save the barcode image on local system.
    /// <code>
    /// BarCodeBuilder builder = new BarCodeBuilder("test-123", BarCodeType.Pdf417);
    /// builder.Save(SaveLocation.Local, "code128.png", ImageFormat.PNG);
    /// </code>
    /// </example>
    public class BarCodeBuilder
    {
        /// <summary>
        /// Default constructor, initialize the BarcodeBuilder class
        /// Default symbology is Code128
        /// </summary>
        public BarCodeBuilder()
        {
            this.BarCodeType = BarCodeType.Code128;
            this.Codetext = "test-123";
            this.ImageFormat = ImageFormat.PNG;
        }

        /// <summary>
        /// Constructor with codetext and barcode type
        /// </summary>
        /// <param name="codetext">Barcode value</param>
        /// <param name="barcodeType">Barcode type</param>
        public BarCodeBuilder(String codetext, BarCodeType barcodeType)
        {
            this.BarCodeType = barcodeType;
            this.Codetext = codetext;
            this.ImageFormat = ImageFormat.PNG;
        }

        /// <summary>
        /// Get or set Codetext of the barcode
        /// </summary>
        public string Codetext { get; set; }

        /// <summary>
        /// Get or set the type of barcode to be generated e.g. Code128, Code39Standard, Pdf417 etc
        /// </summary>
        public BarCodeType BarCodeType { get; set; }

        /// <summary>
        /// Get or set the image format of the barcode. Default is PNG
        /// </summary>
        public ImageFormat ImageFormat { get; set; }

        /// <summary>
        /// Set X resolution in DPI. Default is 96.
        /// </summary>
        public float ResolutionX { get; set; }

        /// <summary>
        /// Set Y resolution in DPI. Default is 96.
        /// </summary>
        public float ResolutionY { get; set; }

        /// <summary>
        /// Set X dimension. Default is 0.7.
        /// </summary>
        public float DimensionX { get; set; }

        /// <summary>
        /// Set Y dimension. Default is 2.
        /// </summary>
        public float DimensionY { get; set; }

        /// <summary>
        /// Folder name on server, where barcode is to be saved. To be used with Save() method with SaveLocation.Server parameter
        /// </summary>
        public string FolderName { get; set; }

        /// <summary>
        /// Creates the barcode and save the barcode image to the local path provided
        /// Examples:
        /// Save(SaveLocation.Local, "c:\\code128.png", ImageFormat.PNG);
        /// Save(SaveLocation.Server, "test-1234.png", ImageFormat.PNG);
        /// </summary>
        /// <param name="SaveLocation">Location where barcode needs to be saved, local or Saaspose server</param>
        /// <param name="outputPath">Location where barcode is to be saved</param>
        /// <param name="ImageFormat">Image format</param>
        public GenerationResponse Save(SaveLocation saveLocation, string outputPath, ImageFormat imageFormat)
        {
            PerformValidations();
            
            // If image needs to be saved locally
            if (saveLocation == SaveLocation.Local)
            {
                // Build URL with querystring request parameters
                string uri = UriBuilder("");
                
                // Send the request to Saaspose server
                Stream responseStream = Utils.ProcessCommand(Utils.Sign(uri), "GET");
                // Read the response, in this case the response is a Stream that contains barcode image
                // So, just save the response stream to a local image file
                using (Stream file = File.OpenWrite(outputPath))
                {
                    CopyStream(responseStream, file);
                }
                responseStream.Close();

                GenerationResponse response = new GenerationResponse();
                response.Status = "OK";
                return response;
            }
            else if (saveLocation == SaveLocation.Server)
            {
                // Build URL with querystring request parameters
                string uri = UriBuilder(outputPath);

                // Send the request to Saaspose server
                Stream responseStream = Utils.ProcessCommand(Utils.Sign(uri), "PUT");
                StreamReader reader = new StreamReader(responseStream);
                // Read the response
                string strJSON = reader.ReadToEnd();


                //Parse the json string to JObject
                JObject parsedJSON = JObject.Parse(strJSON);


                //Deserializes the JSON to a object. 
                GenerationResponse barcodeGenerationResponse = JsonConvert.DeserializeObject<GenerationResponse>(parsedJSON.ToString());

                return barcodeGenerationResponse;
            }

            // Return null, if anything goes wrong
            return null;
        }

        /// <summary>
        /// Creates the barcode and save the barcode image to the supplied stream
        /// Example: Save(SaveLocation.Local, imgStream, ImageFormat.PNG);
        /// </summary>
        /// <param name="imageStream">Stream where image will be saved</param>
        /// <param name="ImageFormat">Image format</param>
        public GenerationResponse Save(SaveLocation saveLocation, Stream imageStream, ImageFormat imageFormat)
        {
            PerformValidations();

            // Build URL with querystring request parameters
            string uri = UriBuilder("");

            // Send the request to Saaspose server
            Stream responseStream = Utils.ProcessCommand(Utils.Sign(uri), "GET");
            // Read the response, in this case the response is a Stream that contains barcode image
            // Just copy the response stream to the image stream that user passed
            CopyStream(responseStream, imageStream);
            // close the response stream
            responseStream.Close();

            GenerationResponse response = new GenerationResponse();
            response.Status = "OK";
            return response;
        }

        /// <summary>
        /// Build the URI
        /// </summary>
        private string UriBuilder(string imageFileName)
        {
            // Initialize with server URI, text and type, which are must
            string uri = Saaspose.Common.Product.BaseProductUri + "/barcode/";
            // imageFileName is to be handled in case of PUT request, where barcode is to be saved on Saaspose server
            if (imageFileName != null && imageFileName.Trim().Length > 0)
                uri += imageFileName + "/";
            uri += "generate?text=" + Codetext + "&type=" + BarCodeType;

            // Add image format parameter
            uri += "&format=" + ImageFormat;

            // Add folder parameter
            if (FolderName != null && FolderName.Trim().Length > 0)
                uri += "&folder=" + FolderName;

            // Add x resolution parameter
            if (ResolutionX != 0.0f)
                uri += "&resolutionX=" + ResolutionX;

            // Add y resolution parameter
            if (ResolutionY != 0.0f)
                uri += "&resolutionY=" + ResolutionY;

            // Add x dimension parameter
            if (DimensionX != 0.0f)
                uri += "&dimensionX=" + DimensionX;

            // Add y dimension parameter
            if (DimensionY != 0.0f)
                uri += "&dimensionY=" + DimensionY;

            // return the URI
            return uri;
        }

        /// <summary>
        /// Perform validations locally
        /// </summary>
        private void PerformValidations()
        {
            // Throw exception if App Key is empty
            if (SaasposeApp.AppKey == null || SaasposeApp.AppKey.Trim().Length == 0)
                throw new Exception("App Key is not specified. Please set the App Key property.");

            // Throw exception if App SID is empty
            if (SaasposeApp.AppSID == null || SaasposeApp.AppSID.Trim().Length == 0)
                throw new Exception("App SID is not specified. Please set App SID property.");

            // Throw exception if codetext is empty
            if (Codetext == null || Codetext.Trim().Length == 0)
                throw new Exception("Codetext is not specified. Please set Codetext property.");
        }

        /// <summary>
        /// Copies the contents of input to output. Doesn't close either stream.
        /// </summary>
        private static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }
    }
}
