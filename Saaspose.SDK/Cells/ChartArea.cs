using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class ChartArea
    {
        public ChartArea()
        { 
        
        }

        public LinkResponse link { get; set; }
        public bool AutoScaleFont { get; set; }
        public BackgroundMode BackgroundMode { get; set; }
        public Font Font { get; set; }
        public FillFormat FillFormat { get; set; }
        public int Height { get; set; }
        public bool IsAutomaticSize { get; set; }
        public bool IsInnerMode { get; set; }
        public bool Shadow { get; set; }
        public int Width { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


    }
}
