using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Storage
{
    /// <summary>
    /// represents the storage type (Amazon S3, DropBox, Google Drive, Google Cloud or Windows Azure etc.)
    /// </summary>
    public enum StorageType
    {
        ThirdParty,
        AmazonS3,
    }
}
