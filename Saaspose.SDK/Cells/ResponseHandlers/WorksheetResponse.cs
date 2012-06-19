using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    ///  Represents response from the worksheet resource
    /// </summary>
    public class WorksheetResponse : Saaspose.Common.BaseResponse
    {
       
        public AutoShapesResponse AutoShapes { get; set; }

        public CellsResponse Cells { get; set; }
     
        public ChartsResponse Charts { get; set; }

        public CommentsResponse Comments { get; set; }

        public ConditionalFormattingResponse ConditionalFormattings { get; set; }

        public HyperlinksResponse Hyperlinks { get; set; }

        public MergedCellsResponse MergedCells { get; set; }

        public OleObjectsResponse OleObjects { get; set; }

        public PicturesResponse Pictures { get; set; }

        public LinkResponse link { get; set; }

        public ValidationsResponse Validations { get; set; }

        public RowsResponse Rows { get; set; }

        public ColumnsResponse Columns { get; set; }

        public Worksheet Worksheet { get; set; }

    }
}
