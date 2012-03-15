using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    ///  Represents response from the worksheets resource
    /// </summary>
    public class WorksheetsResponse : Saaspose.Common.BaseResponse
    {

        public List<Worksheet> WorksheetList { get; set; }

        public LinkResponse Link { get; set; }

    }
}
