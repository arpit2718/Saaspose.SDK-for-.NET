using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    ///  Represents response from the Conditional Formatting resource
    /// </summary>
    public class ConditionalFormattingResponse : Saaspose.Common.BaseResponse
    {        
        public LinkResponse link { get; set; }

    }
}
