using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class Font
    {
        public Font()
        { 
        
        }

        public string Name {get; set;}
        public Double Size {get; set;}
        public Color Color { get; set; }
        public Double DoubleSize { get; set;}
        public bool IsBold { get; set;}
        public bool IsItalic {get; set;}
        public bool IsSubscript {get; set;}
        public bool IsStrikeout {get; set;}
        public bool IsSuperscript {get; set;}
        public string Underline {get; set;}


    }
}
