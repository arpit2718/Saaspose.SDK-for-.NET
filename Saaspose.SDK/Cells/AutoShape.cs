using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class AutoShape
    {
        /// <summary>
        /// AutoShape Class Default Constructor
        /// </summary>
        public AutoShape()
        {

        }
       
        public string Name { get; set; }
        public string AutoShapeType { get; set; }
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
        public string LinkedCell { get; set; }
        public string HtmlText { get; set; }
        public string Text { get; set; }
        public string AlternativeText { get; set; }
        public string TextHorizontalAlignment { get; set; }
        public string TextHorizontalOverflow { get; set; }
        public string TextOrientationType { get; set; }
        public string TextVerticalAlignment { get; set; }
        public string TextVerticalOverflow { get; set; }
        public bool IsGroup { get; set; }
        public bool IsHidden { get; set; }
        public bool IsLockAspectRatio { get; set; }
        public bool IsLocked { get; set; }
        public bool IsPrintable { get; set; }
        public bool IsTextWrapped { get; set; }
        public int ZOrderPosition { get; set; }
    }
}
