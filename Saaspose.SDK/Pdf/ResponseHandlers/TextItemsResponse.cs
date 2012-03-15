using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents response from the textitems resource
    /// </summary>
    class TextItemsResponse : Saaspose.Common.BaseResponse
    {
        public TextItemsEnvelop TextItems { get; set; }

    }
}
