using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    /// Represents response from the Autoshape resource
    /// </summary>
    public class AutoShapesResponse : Saaspose.Common.BaseResponse
    {
       
        public LinkResponse link { get; set; }
                
        public List<LinkResponse> AuotShapeList { get; set; }

        public AutoShape AutoShape { get; set; }
    }
}
