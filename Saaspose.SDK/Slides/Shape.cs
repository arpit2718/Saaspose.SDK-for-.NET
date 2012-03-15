using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Slides
{
    /// <summary>
    /// represents a single property of the document
    /// </summary>
    public class Shape
    {
        public Shape() { }

        public string AlternativeText { get; set; }
        public float Height { get; set; }
        public bool Hidden { get; set; }
        public string Name { get; set; }
        public float Width { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public List<LinkResponse> Shapes { get; set; }
        public FillFormatURI FillFormat { get; set; }
        public LineFormatURI LineFormat { get; set; } 
    }
}
