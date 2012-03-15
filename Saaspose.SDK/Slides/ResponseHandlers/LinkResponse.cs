using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Slides
{
    /// <summary>
    /// represents link part of the response
    /// </summary>
    public class LinkResponse
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }
}
