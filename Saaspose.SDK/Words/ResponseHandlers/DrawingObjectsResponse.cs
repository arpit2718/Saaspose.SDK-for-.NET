using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Words
{
    public class DrawingObjectsResponse : Saaspose.Common.BaseResponse
    {
        public DrawingObjects DrawingObjects { get; set; }
        public DrawingObject DrawingObject { get; set; }
    }
}
