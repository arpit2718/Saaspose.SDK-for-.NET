using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents Text in PDF document
    /// </summary>
    public class TextReplace
    {
        public TextReplace() { }

        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Regex { get; set; }

    }
}
