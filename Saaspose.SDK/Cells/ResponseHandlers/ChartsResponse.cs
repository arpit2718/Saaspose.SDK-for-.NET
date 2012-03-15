using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    ///  Represents response from the Charts resource
    /// </summary>
    public class ChartsResponse : Saaspose.Common.BaseResponse
    {        
        public LinkResponse link { get; set; }

        /// <summary>
        /// Document Property
        /// </summary>
        public List<LinkResponse> ChartList { get; set; }

        public Chart Chart { get; set; }

    }
}
