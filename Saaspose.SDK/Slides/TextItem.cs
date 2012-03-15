using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Slides
{
    /// <summary>
    /// represents a single text item
    /// </summary>
    public class TextItem
    {
        public TextItem() { }

        public string Text { get; set; }
        public ShapeURI Uri { get; set; }
    }
}
