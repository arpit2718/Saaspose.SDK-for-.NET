using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents response of a single text item
    /// </summary>
    public class TextItemResponse : Saaspose.Common.BaseResponse
    {
        public TextItem TextItem { get; set; }

    }
}
