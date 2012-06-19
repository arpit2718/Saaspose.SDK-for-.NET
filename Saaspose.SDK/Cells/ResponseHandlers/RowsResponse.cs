using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    ///  Represents response from the Rows resource
    /// </summary>
    public class RowsResponse : Saaspose.Common.BaseResponse
    {
        
        public LinkResponse link { get; set; }

        public int RowCount { get; set; }
               
        public List<LinkResponse> RowsList { get; set; }


        public Row Row { get; set; }
       
    }
}
