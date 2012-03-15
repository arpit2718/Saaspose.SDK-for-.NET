using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class Chart
    {
        public Chart()
        { 
        
        }
               
        public string Name { get; set;}
        public string Type{ get; set;}
        public string Placement { get; set;}
        public int UpperLeftRow{ get; set;}
        public int Top { get; set;}
        public int UpperLeftColumn{ get; set;}
        public int Left { get; set;}
        public int LowerRightRow{ get; set;}
        public int Bottom { get; set; }
        public int LowerRightColumn { get; set;}
        public int Right { get; set; }
        public int Width{ get; set;}
        public int Height { get; set;}
        public int X{ get; set;}
        public int Y { get; set;}
        public string AlternativeText{ get; set;}
        public bool IsGroup { get; set; }
        public bool IsHidden { get; set;}
        public bool IsLockAspectRatio{ get; set;}
        public bool IsLocked { get; set;}
        public bool IsPrintable{ get; set;}
        public bool AutoScaling { get; set;}
        public int DepthPercent{ get; set;}
        public int Elevation { get; set;}
        public int FirstSliceAngle{ get; set;}
        public int GapDepth { get; set;}
        public int GapWidth{ get; set;}
        public short HeightPercent { get; set;}
        public bool HidePivotFieldButtons{ get; set;}
        public bool Is3D { get; set; }
        public bool IsRectangularCornered { get; set;}
        public short Perspective{ get; set;}
        public string PivotSource { get; set;}
        public string PlotEmptyCellsType{ get; set;}
        public bool PlotVisibleCells { get; set;}
        public string PrintSize{ get; set;}
        public bool RightAngleAxes { get; set;}
        public int RotationAngle{ get; set;}
        public bool ShowDataTable { get; set;}
        public bool ShowLegend{ get; set;}
        public bool SizeWithWindow { get; set;}
        public int Style{ get; set;}
        public bool WallsAndGridlines2D { get; set;}
        public int ZOrderPosition{ get; set;}

    }
}
