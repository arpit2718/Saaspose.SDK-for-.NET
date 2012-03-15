using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Common;

namespace Saaspose.Storage
{
    /// <summary>
    /// represents response from the Folder resource
    /// </summary>
    public class FolderResponse : BaseResponse
    {
        public List<Saaspose.Storage.File> Files { get; set; } 
    }
}
