using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents response from the documentProperties resource
    /// </summary>
    class DocumentPropertiesResponse : Saaspose.Common.BaseResponse
    {
        public DocumentPropertiesEnvelop DocumentProperties { get; set; }

    }
}
