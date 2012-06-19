using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
   
    /// <summary>
    /// represents response from the Pdf Links resource
    /// </summary>
    public class PdfLinksResponse : Saaspose.Common.BaseResponse
    {
        public PdfLinksEnvelop Links { get; set; }

    }

}
