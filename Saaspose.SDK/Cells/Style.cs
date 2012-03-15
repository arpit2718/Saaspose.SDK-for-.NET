using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class Style
    {
        public Style()
        { 
        
        }

        public LinkResponse link { get; set; }
        public string Name { get; set; }
        public string CultureCustom { get; set; }
        public string Custom { get; set; }
        public Color BackgroundColor { get; set; }
        public Color ForegroundColor { get; set; }
        public string HorizontalAlignment { get; set; }
        public string VerticalAlignment { get; set; }
        public bool IsFormulaHidden { get; set; }
        public bool IsDateTime { get; set; }
        public bool IsTextWrapped { get; set; }
        public bool IsGradient { get; set; }
        public bool IsLocked { get; set; }
        public bool IsPercent { get; set; }
        public bool ShrinkToFit { get; set; }
        public int IndentLevel { get; set; }
        public int Number { get; set; }
        public int RotationAngle { get; set; }
        public int Rotation { get; set; }
        public string Pattern { get; set; }
        public string TextDirection { get; set; }
        public List<Border> BorderCollection { get; set; }
        public Font Font { get; set; }

    }
}
