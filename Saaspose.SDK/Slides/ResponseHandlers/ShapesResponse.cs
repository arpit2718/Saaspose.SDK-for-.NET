using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Slides
{
    /// <summary>
    /// represents response from the images resource
    /// </summary>
    class ShapesResponse : Saaspose.Common.BaseResponse
    {
        public ShapesEnvelop ShapeList { get; set; }

    }
}
