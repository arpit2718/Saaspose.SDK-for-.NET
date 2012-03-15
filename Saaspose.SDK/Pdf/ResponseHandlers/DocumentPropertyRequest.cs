using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents response of a single property
    /// </summary>
    public class DocumentPropertyRequest : Saaspose.Common.BaseResponse
    {
        public DocumentPropertyRequest() { }

        public DocumentPropertyValue DocumentProperty { get; set; }

    }
}
