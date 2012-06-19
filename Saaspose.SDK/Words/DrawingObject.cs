using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Words
{
    public class DrawingObject
    {

        public DrawingObject() { }

        public LinkResponse link { get; set; }
        public float Height { get; set; }
        public LinkResponse ImageDataLink { get; set; }
        public LinkResponse OleDataLink { get; set; }
        public List<LinkResponse> RenderLinks { get; set; }
        public float Width { get; set; }

    }

}
