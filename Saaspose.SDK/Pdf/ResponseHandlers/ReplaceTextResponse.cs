using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents response of a single text item
    /// </summary>
    public class ReplaceTextResponse : Saaspose.Common.BaseResponse
    {
        public List<LinkResponse> Links { get; set; }
        public int Matches { get; set; }        
    }
}
