using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Words
{
    public class LinkResponse
    {
        public LinkResponse() { }

        /// <summary>
        /// Link Href
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Link Rel
        /// </summary>
        public string Rel { get; set; }

        /// <summary>
        /// Link Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Link Type
        /// </summary>
        public string Type { get; set; }
    }
}
