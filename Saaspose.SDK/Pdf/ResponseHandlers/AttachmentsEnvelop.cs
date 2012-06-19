using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
   
    /// <summary>
    /// represents container part of the Attachment resource response
    /// </summary>
   public  class AttachmentsEnvelop
    {
        public List<LinkResponse> Links { get; set; }
        public List<Attachment> List { get; set; }
    }
}
