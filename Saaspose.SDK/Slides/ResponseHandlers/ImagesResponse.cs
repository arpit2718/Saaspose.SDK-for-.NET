using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Slides
{
    /// <summary>
    /// represents response from the images resource
    /// </summary>
    class ImagesResponse : Saaspose.Common.BaseResponse
    {
        public ImagesEnvelop Images { get; set; }

    }
}
