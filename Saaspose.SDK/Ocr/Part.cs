using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.OCR
{
    class Part
    {
        public bool Bold { get; set; }
        public string FontName { get; set; }
        public float FontSize { get; set; }
        public bool Italic { get; set; }
        public string Text { get; set; }
        public bool Underline { get; set; }
    }
}
