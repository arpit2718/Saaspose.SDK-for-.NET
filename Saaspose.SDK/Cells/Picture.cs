using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class Picture
    {
        public Picture()
        {

        }
        public void GetPicture(ImageFormat imageFormat)
        {

        }

        public string Name { get; set; }
        public string Placement { get; set; }
        public int UpperLeftRow { get; set; }
        public int Top { get; set; }
        public int UpperLeftColumn { get; set; }
        public int Left { get; set; }
        public int LowerRightRow { get; set; }
        public int Bottom { get; set; }
        public int LowerRightColumn { get; set; }
        public int Right { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int RotationAngle { get; set; }
        public bool IsGroup { get; set; }
        public bool IsHidden { get; set;}
        public bool IsLockAspectRatio{ get; set;}
        public bool IsLocked { get; set;}
        public bool IsPrintable{ get; set;}
        public string BorderLineColor { get; set;}
        public double BorderWeight{ get; set;}
        public int OriginalHeight { get; set; }
        public int OriginalWidth { get; set; }
        public string ImageFormat { get; set; }
        public string SourceFullName { get; set;}
        public int ZOrderPosition{ get; set;}

    }
}
