using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents container part of the Annotations resource response
    /// </summary>
   public  class AnnotationsEnvelop
    {
        public List<LinkResponse> Links { get; set; }
        public List<Annotation> List { get; set; }
    }
}
