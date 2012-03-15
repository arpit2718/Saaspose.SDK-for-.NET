using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Slides
{
    /// <summary>
    /// represents link part of the response
    /// </summary>
    public class UriResponse
    {
        public string Href { get; set; }
        public string Relation { get; set; }
        public string LinkType { get; set; }
        public string Title { get; set; }
    }
}
