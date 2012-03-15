using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Saaspose.Storage
{
    /// <summary>
    /// represents collection of File objects
    /// </summary>
    public class FileCollection
    {
        private FileCollection() { }
        /// <summary>
        /// Represents a list fo File Objects.
        /// </summary>
        public FileCollection File { get; set; }
        /// <summary>
        /// returns a list of File objects
        /// </summary>
        public static List<Saaspose.Storage.File> getFilesList(string strJSON)
        {
            try
            {

                JObject parsedJSON = JObject.Parse(strJSON);
                List<Saaspose.Storage.File> files = new List<Saaspose.Storage.File>();

                FolderResponse folderResponse = JsonConvert.DeserializeObject<FolderResponse>(parsedJSON.ToString());

                files = folderResponse.Files;

                return files;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
