using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Common;

namespace Saaspose.Storage
{
    /// <summary>
    /// represents the response from Exist resource
    /// </summary>
    public class ExistResponse : BaseResponse
    {
        public FileExist FileExist { get; set; }
    }
}
