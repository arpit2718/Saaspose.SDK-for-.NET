using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents a single property of the document
    /// </summary>
    public class FormField
    {
        public FormField() { }

        public List<LinkResponse> Links { get; set; }
        public string Name { get; set; }
        public string[] SelectedItems { get; set; }
        public int Type { get; set; }
        public string[] Values { get; set; }


    }
}
