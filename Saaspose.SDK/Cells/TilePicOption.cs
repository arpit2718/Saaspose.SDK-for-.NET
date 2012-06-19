using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class TilePicOption
    {
        public TilePicOption()
        { 
        
        }

        public double OffsetX { get; set; }
        public double offsetY { get; set; }
        public double ScaleX { get; set; }
        public double ScaleY { get; set; }
        public RectangleAlignmentType AlignmentType { get; set; }
        public MirrorType MirrorType { get; set; } 

    }
}
