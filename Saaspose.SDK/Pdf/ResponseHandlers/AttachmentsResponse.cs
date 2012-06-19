using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
 
    /// <summary>
    /// represents response from the attachments resource
    /// </summary>
    public class AttachmentsResponse : Saaspose.Common.BaseResponse
    {
        public AttachmentsEnvelop Attachments { get; set; }

    }

}
