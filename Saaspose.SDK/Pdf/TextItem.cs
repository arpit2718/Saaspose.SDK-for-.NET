using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents a single text item
    /// </summary>
    public class TextItem
    {
        public TextItem() { }

        public List<LinkResponse> Links { get; set; }
        public TextFormat Format { get; set; }
        public string Text { get; set; }

    }
}
