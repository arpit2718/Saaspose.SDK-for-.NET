using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Common;

namespace Saaspose.Storage
{
    /// <summary>
    /// represents response of the Disc resource
    /// </summary>
    public  class DiscResponse : BaseResponse
    {
        public DiscUsage DiscUsage { get; set; }
    }
}
