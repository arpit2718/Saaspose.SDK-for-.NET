using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    public class WorkbookResponse : Saaspose.Common.BaseResponse
    {
        /// <summary>
        /// Document Properties response
        /// </summary>
        public DocumentPropertiesResponse DocumentProperties { get; set; }

        /// <summary>
        /// Worksheets response
        /// </summary>
        public WorksheetsResponse Worksheets { get; set; }

        /// <summary>
        /// Names response
        /// </summary>
        public NamesResponse Names { get; set; }

        /// <summary>
        /// Text Items response
        /// </summary>
        public TextItemsResponse TextItems { get; set; }

        /// <summary>
        /// Document Property response
        /// </summary>
        public DocumentProperty DocumentProperty { get; set; }

        /// <summary>
        /// Workbook Reponse
        /// </summary>
        public Workbook Workbook { get; set; }

        /// <summary>
        /// Worksheet Object
        /// </summary>
        public Worksheet Worksheet { get; set; }

        /// <summary>
        /// Name Object
        /// </summary>
        public Name Name { get; set; }

        /// <summary>
        /// TextItem Object
        /// </summary>
        public TextItem TextItem { get; set; }

        /// <summary>
        /// Style Object
        /// </summary>
        public Style Style { get; set; }
    }
}
