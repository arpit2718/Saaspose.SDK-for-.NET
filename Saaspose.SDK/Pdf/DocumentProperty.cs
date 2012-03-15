using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents a single property of the document
    /// </summary>
    public class DocumentProperty
    {
        public DocumentProperty() { }

        public List<LinkResponse> Links { get; set; }
        public bool BuiltIn { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

    }
}
