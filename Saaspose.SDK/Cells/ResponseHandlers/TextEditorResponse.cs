using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    public class TextEditorResponse : Saaspose.Common.BaseResponse
    {
         /// <summary>
        /// Text Items response
        /// </summary>
        public TextItemsResponse TextItems { get; set; }
   
        /// <summary>
        /// TextItem Object
        /// </summary>
        public TextItem TextItem { get; set; }

        /// <summary>
        /// Style Object
        /// </summary>
        public int Matches { get; set; }
    }
}
