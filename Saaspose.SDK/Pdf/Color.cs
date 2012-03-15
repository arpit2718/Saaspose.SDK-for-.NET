using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents a single text item
    /// </summary>
    public class Color
    {
        public Color() { }

        public List<LinkResponse> Links { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int G { get; set; }
        public int R { get; set; }

        

    }
}
