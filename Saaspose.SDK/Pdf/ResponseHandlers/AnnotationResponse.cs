using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents response of a single annotation
    /// </summary>
    
    public class AnnotationResponse : Saaspose.Common.BaseResponse
 
    {
     public AnnotationResponse() { }

     public Annotation  Annotation { get; set; }

    }
}
