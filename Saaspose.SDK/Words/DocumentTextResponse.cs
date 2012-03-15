using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Words
{
    public class DocumentTextResponse : Saaspose.Common.BaseResponse
    {
        /// <summary>
        /// Document text items response
        /// </summary>
        public DocumentTextItemsResponse TextItems { get; set; }
    }
}
