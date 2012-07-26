using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Slides;

namespace Saaspose.Slides
{
    public class Placeholder
    {
        public UriResponse SelfUri { get; set; }
        public int Index { get; set; }
        public Orientation Orientation { get; set; }
        public Size Size { get; set; }
        public Saaspose.Slides.Type Type { get; set; }
        public ShapeURI Shape { get; set; }

    }
}
