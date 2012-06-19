using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents response from the annotations resource
    /// </summary>
    public class AnnotationsResponse : Saaspose.Common.BaseResponse
    {
        public AnnotationsEnvelop Annotations { get; set; }

    }

  }
