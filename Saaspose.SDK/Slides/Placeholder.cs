using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Slides;
using Saaspose.SDK.Slides.Enums;

namespace Saaspose.SDK.Slides
{
    public class Placeholder
    {
        public UriResponse SelfUri { get; set; }
        public int Index { get; set; }
        public Orientation Orientation { get; set; }
        public Size Size { get; set; }
        public Saaspose.SDK.Slides.Enums.Type Type { get; set; }
        public ShapeURI Shape { get; set; }

    }
}
