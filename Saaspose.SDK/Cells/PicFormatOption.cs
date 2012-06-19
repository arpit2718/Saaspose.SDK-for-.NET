using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class PicFormatOption
    {
        public PicFormatOption()
        { 
        
        }

        public FillPictureType Type { get; set; }
        public double Scale { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }
        public double Top { get; set; }
        public double Bottom { get; set; }

    }
}
