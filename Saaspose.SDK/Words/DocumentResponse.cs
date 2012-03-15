using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Words
{
    public class DocumentResponse : Saaspose.Common.BaseResponse
    {
        /// <summary>
        /// Document Properties response
        /// </summary>
        public DocumentPropertiesResponse DocumentProperties { get; set; }

        /// <summary>
        /// Document Property response
        /// </summary>
        public DocumentProperty DocumentProperty { get; set; }
    }
}
