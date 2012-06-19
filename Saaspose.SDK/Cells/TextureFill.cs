using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class TextureFill
    {
        public TextureFill()
        { 
        
        }

        public TextureType Ttype { get; set; }
        public double Transperancy { get; set; }
        public TilePicOption TilePicOption { get; set; }
        public PicFormatOption PicFormatOption { get; set; }
        public string Image { get; set; }
        
    }
}
