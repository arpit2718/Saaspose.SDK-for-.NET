using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class Line
    {
        public Line()
        { 
        
        }

        public LinkResponse Link { get; set; }
        public bool IsAuto { get; set; }
        public bool IsVisible { get; set; }
        public bool isAutomaticColor { get; set; }
        public Color Color { get; set; }
        public double Transparency { get; set; }
        public LineType Style { get; set; }
        public WeightType WeightType { get; set; }
        public double WeightPt { get; set; }
    }
}
