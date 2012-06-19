using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    ///  Represents response from the Column resource
    /// </summary>
    public class ColumnsResponse : Saaspose.Common.BaseResponse
    {
        
        public LinkResponse link { get; set; }

        public int MaxColumn { get; set; }
               
        public List<LinkResponse> ColumnsList { get; set; }


        public Column Column { get; set; }
       
    }
}
