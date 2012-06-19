using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
       
    /// <summary>
    /// Represents Chart Types
    /// </summary>
    public enum ChartType
    {
        Area, 
        AreaStacked, 
        Area100PercentStacked, 
        Area3D, 
        Area3DStacked, 
        Area3D100PercentStacked, 
        Bar, 
        BarStacked, 
        Bar100PercentStacked, 
        Bar3DClustered,
        Bar3DStacked, 
        Bar3D100PercentStacked, 
        Bubble, 
        Bubble3D, 
        Column, 
        ColumnStacked, 
        Column100PercentStacked, 
        Column3D, 
        Column3DClustered, 
        Column3DStacked,
        Column3D100PercentStacked, 
        Cone, 
        ConeStacked,
        Cone100PercentStacked, 
        ConicalBar, 
        ConicalBarStacked, 
        ConicalBar100PercentStacked, 
        ConicalColumn3D,
        Cylinder, 
        CylinderStacked, 
        Cylinder100PercentStacked, 
        CylindricalBar, 
        CylindricalBarStacked, 
        CylindricalBar100PercentStacked, 
        CylindricalColumn3D,
        Doughnut, 
        DoughnutExploded, 
        Line, 
        LineStacked, 
        Line100PercentStacked, 
        LineWithDataMarkers, 
        LineStackedWithDataMarkers, 
        Line100PercentStackedWithDataMarkers, 
        Line3D,
        Pie, 
        Pie3D, 
        PiePie, 
        PieExploded, 
        Pie3DExploded, 
        PieBar, 
        Pyramid, 
        PyramidStacked, 
        Pyramid100PercentStacked, 
        PyramidBar, 
        PyramidBarStacked, 
        PyramidBar100PercentStacked,
        PyramidColumn3D, 
        Radar, 
        RadarWithDataMarkers, 
        RadarFilled, 
        Scatter, 
        ScatterConnectedByCurvesWithDataMarker, 
        ScatterConnectedByCurvesWithoutDataMarker,
        ScatterConnectedByLinesWithDataMarker, 
        ScatterConnectedByLinesWithoutDataMarker, 
        StockHighLowClose, 
        StockOpenHighLowClose, 
        StockVolumeHighLowClose,
        StockVolumeOpenHighLowClose, 
        Surface3D, 
        SurfaceWireframe3D, 
        SurfaceContour, 
        SurfaceContourWireframe 

    }
}

