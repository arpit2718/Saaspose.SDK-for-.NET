using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class FillFormat
    {
        public FillFormat()
        { 
        
        }

        public LinkResponse link { get; set; }
        public FillType Type { get; set; }
        public SolidFill SolidFill { get; set; }
        public PatternFill PatternFill { get; set; }
        public TextureFill TextureFill { get; set; }
        public GradientFill GradientFill { get; set; }
       

    }
}
