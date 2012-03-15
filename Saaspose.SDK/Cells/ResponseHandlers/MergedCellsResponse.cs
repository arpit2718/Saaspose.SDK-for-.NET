using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    ///  Represents response from the MergedCells resource
    /// </summary>
    public class MergedCellsResponse : Saaspose.Common.BaseResponse
    {      
        public LinkResponse link { get; set; }

        public int Count { get; set; }

        public List<LinkResponse> MergedCellList { get; set; }

        public MergedCell MergedCell { get; set; }

    }
}
