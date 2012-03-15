using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class Comment
    {
        public Comment()
        { 
        
        }

        public string CellName { get; set; }
        public string Author { get; set; }
        public string HtmlNote { get; set; }
        public string Note { get; set; }
        public bool AutoSize { get; set; }
        public bool IsVisible { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string TextHorizontalAlignment { get; set; }
        public string TextOrientationType { get; set; }
        public string TextVerticalAlignment { get; set; }

    }
}
