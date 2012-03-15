using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents response of a single text item
    /// </summary>
    public class TextFormatResponse : Saaspose.Common.BaseResponse
    {
        public TextFormat TextFormat { get; set; }

    }
}
