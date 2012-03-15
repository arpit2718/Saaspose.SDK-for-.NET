using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Words
{
    public class DocumentResourceResponse : Saaspose.Common.BaseResponse
    {
        /// <summary>
        /// Document
        /// </summary>
        public Document Document { get; set; }
    }
}
