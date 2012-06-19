using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
  
    /// <summary>
    /// represents response of a single Attachment
    /// </summary>

    public class AttachmentResponse : Saaspose.Common.BaseResponse
    {
        public AttachmentResponse() { }

        public Attachment Attachment { get; set; }

    }
}
