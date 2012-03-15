using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Storage
{
    /// <summary>
    /// Represents FileExist Saaspose response structure.
    /// </summary>
    public class FileExist
    {

            /// <summary>
            /// Indicates whether a file exists or not.
            /// </summary>
            public bool IsExist { get; set; }
            /// <summary>
            /// Indicates whether the file or folder.
            /// </summary>
            public bool IsFolder { get; set; }
       
    }
}
