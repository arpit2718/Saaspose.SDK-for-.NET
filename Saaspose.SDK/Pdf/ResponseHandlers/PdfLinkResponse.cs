using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents response of a single Pdf Link
    /// </summary>   
    public class PdfLinkResponse : Saaspose.Common.BaseResponse
    {
        public PdfLinkResponse() { }

        public Link Link { get; set; }

    }
}
