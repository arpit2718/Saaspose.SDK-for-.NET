using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Storage
{
    /// <summary>
    /// Represents a File part of the Folder resource response
    /// </summary>
    public class File
    {
        public File()
        { }
        /// <summary>
        /// Represents file name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates whether a folder or file.
        /// </summary>
        public bool IsFolder { get; set; }

        /// <summary>
        /// Represents last modification date of file or folder.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Represents the size of the File or Folder.
        /// </summary>
        public long Size { get; set; }
    }
}
