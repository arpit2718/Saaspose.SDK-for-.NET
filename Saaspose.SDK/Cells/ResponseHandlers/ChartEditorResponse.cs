using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    ///  Represents response from the Charts resource
    /// </summary>
    public class ChartEditorResponse : Saaspose.Common.BaseResponse
    {

        public ChartArea ChartArea { get; set; }

        public FillFormat FillFormat { get; set; }

        public Line Line { get; set; }

    }
}
