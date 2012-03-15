using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Slides
{
    /// <summary>
    /// represents container part of the slides resource response
    /// </summary>
    public class TextItemsEnvelop
    {

        public List<string> AlternateLinks { get; set; }
        public List<ShapeURI> Links { get; set; }
        public UriResponse SelfUri { get; set; }
        public List<TextItem> Items { get; set; }
    }
}
