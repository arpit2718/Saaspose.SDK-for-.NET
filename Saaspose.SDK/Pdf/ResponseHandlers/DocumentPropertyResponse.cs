using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents response of a single property
    /// </summary>
    public class DocumentPropertyResponse : Saaspose.Common.BaseResponse
    {
        public DocumentProperty DocumentProperty { get; set; }

    }
}
