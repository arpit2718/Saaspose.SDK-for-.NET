using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Common;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Saaspose.Storage
{
    /// <summary>
    /// Main class that provides methods to perform all the transactions on the storage of a Saaspose Application.
    /// </summary>
    public class Folder
    {
        //private string strURIFolder = "http://api.saaspose.com/v1.0/storage/folder/";
        //private string strURIFile = "http://api.saaspose.com/v1.0/storage/file/";
        //private string strURIExist = "http://api.saaspose.com/v1.0/storage/exist/";
        //private string strURIDisc = "http://api.saaspose.com/v1.0/storage/disc/";

        private string strURIFolder = Saaspose.Common.Product.BaseProductUri + "/storage/folder/";
        private string strURIFile = Saaspose.Common.Product.BaseProductUri + "/storage/file/";
        private string strURIExist = Saaspose.Common.Product.BaseProductUri + "/storage/exist/";
        private string strURIDisc = Saaspose.Common.Product.BaseProductUri + "/storage/disc/";

        /// <summary>
        /// Sets or gets the app info for which operations to be performed.
        /// </summary>
        public SaasposeApp app { get; set; }
        /// <summary>
        /// Retrives the list of files and folders under the specified folder. Use empty string to specify root folder.
        /// </summary>
        /// <param name="strFolder"></param>
        /// <returns></returns>
        public List<Saaspose.Storage.File> GetFilesList(string strFolder)
        {
            try
            {
                StreamReader reader = new StreamReader(Utils.ProcessCommand(Utils.Sign(this.strURIFolder + strFolder), "GET"));
                //further process JSON response
                string strJSON = reader.ReadToEnd();
                return FileCollection.getFilesList(strJSON);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrives the list of files and folders under the specified folder. 
        /// In case of Amazon S3/Google Cloud storages, the folder's path starts with Amazon S3/Google Cloud Bucket name.
        /// </summary>
        /// <param name="strFolder">In case of Amazon S3/Google Cloud storages, the folder's path starts with Amazon S3/Google Cloud Bucket name.</param>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        /// <returns></returns>
        public List<Saaspose.Storage.File> GetFilesList(string strFolder, StorageType storageType, string storageName)
        {
            try
            {
                //Build URI to get files list
                StringBuilder strURI = new StringBuilder(this.strURIFolder + strFolder);

                strURI.Append("?storage=" + storageName);

                StreamReader reader = new StreamReader(Utils.ProcessCommand(Utils.Sign(strURI.ToString()), "GET"));
                //further process JSON response
                string strJSON = reader.ReadToEnd();
                return FileCollection.getFilesList(strJSON);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Deletes a file from the storage. Use "FolderName/FileName" to specify a file under specific folder.
        /// </summary>
        /// <param name="strFileName"></param>
        public void DeleteFile(string strFileName)
        {
            try
            {
                Utils.ProcessCommand(Utils.Sign(this.strURIFile + strFileName), "DELETE");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a file from any third party storage. Use "FolderName/FileName" to specify a file under specific folder. 
        /// In case of Amazon S3/Google Cloud storages, the folder's path starts with Amazon S3/Google Cloud Bucket name.
        /// </summary>
        /// <param name="strFileName">In case of Amazon S3/Google Cloud storages, the folder's path starts with Amazon S3/Google Cloud Bucket name.</param>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        public void DeleteFile(string strFileName, StorageType storageType, string storageName)
        {
            try
            {
                //Build URI to Delete file
                StringBuilder strURI = new StringBuilder(this.strURIFile + strFileName);

                strURI.Append("?storage=" + storageName);
                Utils.ProcessCommand(Utils.Sign(strURI.ToString()), "DELETE");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes an empty folder from the storage. Use "FolderName/SubFolderName" for sub folders.
        /// </summary>
        /// <param name="strFolderName"></param>
        public void DeleteFolder(string strFolderName)
        {
            try
            {
                Utils.ProcessCommand(Utils.Sign(this.strURIFolder + strFolderName), "DELETE");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes an empty folder from the storage. Use "FolderName/SubFolderName" for sub folders. 
        /// In case of Amazon S3/Google Cloud storages, the folder's path starts with Amazon S3/Google Cloud Bucket name.
        /// </summary>
        /// <param name="strFolderName">In case of Amazon S3/Google Cloud storages, the folder's path starts with Amazon S3/Google Cloud Bucket name.</param>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        public void DeleteFolder(string strFolderName, StorageType storageType, string storageName)
        {
            try
            {
                //Build URI to Delete folder
                StringBuilder strURI = new StringBuilder(this.strURIFolder + strFolderName);

                strURI.Append("?storage=" + storageName);

                Utils.ProcessCommand(Utils.Sign(strURI.ToString()), "DELETE");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Uploads a file from your local machine to specified folder / subfolder on Saaspose storage.
        /// </summary>
        /// <param name="strFile"></param>
        /// <param name="strFolder"></param>
        public void UploadFile(string strFile, string strFolder)
        {
            try
            {
                string strRemoteFileName = System.IO.Path.GetFileName(strFile);
                string strURIRequest = this.strURIFile + (strFolder == "" ? "" : strFolder + "/") + strRemoteFileName;
                string strURISigned = Utils.Sign(strURIRequest);
                Utils.UploadFileBinary(strFile, strURISigned, "PUT");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Uploads a file from your local machine to specified folder / subfolder on Saaspose / 3rd party storage. 
        /// In case of Amazon S3/Google Cloud storages, the folder's path starts with Amazon S3/Google Cloud Bucket name.
        /// </summary>
        /// <param name="strFile"></param>
        /// <param name="strFolder">In case of Amazon S3/Google Cloud storages, the folder's path starts with Amazon S3/Google Cloud Bucket name.</param>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of storage.</param>
        public void UploadFile(string strFile, string strFolder, StorageType storageType, string storageName)
        {
            try
            {
                string strRemoteFileName = System.IO.Path.GetFileName(strFile);

                //Build URI to upload file
                StringBuilder strURI = new StringBuilder(this.strURIFile + (strFolder == "" ? "" : strFolder + "/") +
                    strRemoteFileName);

                strURI.Append("?storage=" + storageName);

                string strURISigned = Utils.Sign(strURI.ToString());
                Utils.UploadFileBinary(strFile, strURISigned, "PUT");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Creates a folder under the specified folder. If no path specified, creates a folder under the root folder.
        /// </summary>
        /// <param name="strFolder"></param>
        public void CreateFolder(string strFolder)
        {
            try
            {
                string strURIRequest = this.strURIFolder + strFolder;
                string strURISigned = Utils.Sign(strURIRequest);

                Utils.ProcessCommand(strURISigned, "PUT");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Creates a folder under the specified folder. If no path specified, creates a folder under the root folder.
        /// In case of Amazon S3/Google Cloud storages, the folder's path starts with Amazon S3/Google Cloud Bucket name.
        /// </summary>
        /// <param name="strFolder">In case of Amazon S3/Google Cloud storages, the folder's path starts with Amazon S3/Google Cloud Bucket name.</param>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        public void CreateFolder(string strFolder, StorageType storageType, string storageName)
        {
            try
            {
                //Build URI to create folder
                StringBuilder strURI = new StringBuilder(this.strURIFolder + strFolder);

                strURI.Append("?storage=" + storageName);

                string strURISigned = Utils.Sign(strURI.ToString());

                Utils.ProcessCommand(strURISigned, "PUT");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Checks whether file or folder exists on the Saaspose storage.
        /// </summary>
        /// <param name="strFolderOrFile"></param>
        /// <returns></returns>
        public FileExist FileExist(string strFolderOrFile)
        {
            try
            {
                string strURIRequest = this.strURIExist + strFolderOrFile;
                string strURISigned = Utils.Sign(strURIRequest);
                StreamReader reader = new StreamReader(Utils.ProcessCommand(strURISigned, "GET"));
                string strJSON = reader.ReadToEnd();
                JObject parsedJSON = JObject.Parse(strJSON);

                ExistResponse existResponse = JsonConvert.DeserializeObject<ExistResponse>(parsedJSON.ToString());

                return existResponse.FileExist;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Checks whether file or folder exists on the Saaspose/3rd party storage. 
        /// In case of Amazon S3/Google Cloud storages, the folder's path starts with Amazon S3/Google Cloud Bucket name.
        /// </summary>
        /// <param name="strFolderOrFile">In case of Amazon S3/Google Cloud storages, the folder's path starts with Amazon S3/Google Cloud Bucket name.</param>
        /// /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        /// <returns></returns>
        public FileExist FileExist(string strFolderOrFile, StorageType storageType, string storageName)
        {
            try
            {
                //Build URI to check file
                StringBuilder strURI = new StringBuilder(this.strURIExist + strFolderOrFile);

                strURI.Append("?storage=" + storageName);

                string strURISigned = Utils.Sign(strURI.ToString());
                StreamReader reader = new StreamReader(Utils.ProcessCommand(strURISigned, "GET"));
                string strJSON = reader.ReadToEnd();
                JObject parsedJSON = JObject.Parse(strJSON);

                ExistResponse existResponse = JsonConvert.DeserializeObject<ExistResponse>(parsedJSON.ToString());

                return existResponse.FileExist;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Provides the total / free disc size in bytes for your app.
        /// </summary>
        /// <returns></returns>
        public DiscUsage GetDiscUsage()
        {
            try
            {
                StreamReader reader = new StreamReader(Utils.ProcessCommand(Utils.Sign(this.strURIDisc), "GET"));

                string strJSON = reader.ReadToEnd();
                JObject parsedJSON = JObject.Parse(strJSON);

                DiscResponse discResponse = JsonConvert.DeserializeObject<DiscResponse>(parsedJSON.ToString());


                return discResponse.DiscUsage;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Provides the total / free disc size in bytes for your 3rd party storage.
        /// </summary>
        /// <returns></returns>
        public DiscUsage GetDiscUsage(StorageType storageType, string storageName)
        {
            try
            {
                //Build URI to get disc usage
                StringBuilder strURI = new StringBuilder(this.strURIDisc);

                strURI.Append("?storage=" + storageName);

                StreamReader reader = new StreamReader(Utils.ProcessCommand(Utils.Sign(strURI.ToString()), "GET"));

                string strJSON = reader.ReadToEnd();
                JObject parsedJSON = JObject.Parse(strJSON);

                DiscResponse discResponse = JsonConvert.DeserializeObject<DiscResponse>(parsedJSON.ToString());


                return discResponse.DiscUsage;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get file from Saaspose server. In case of Amazon S3/Google Cloud storages, the folder's path starts with Amazon S3/Google Cloud Bucket name.
        /// </summary>
        /// <param name="fileName">file name on the server. 
        /// In case of Amazon S3/Google Cloud storages, the folder's path starts with Amazon S3/Google Cloud Bucket name.</param>
        /// <param name="storageType"></param>
        /// <param name="storageName">Name of the storage</param>
        /// <returns></returns>
        public Stream GetFile(string fileName, StorageType storageType, string storageName)
        {
            //Build URI to get file from server
            StringBuilder strURI = new StringBuilder(this.strURIFile + fileName);

            strURI.Append("?storage=" + storageName);

            return Utils.ProcessCommand(Utils.Sign(strURI.ToString()), "GET");
        }

        /// <summary>
        /// Get file from Saaspose server
        /// </summary>
        /// <param name="fileName">file name on the server</param>
        /// <returns></returns>
        public Stream GetFile(string fileName)
        {
            return Utils.ProcessCommand(Utils.Sign(this.strURIFile + fileName), "GET");
        }
    }
}