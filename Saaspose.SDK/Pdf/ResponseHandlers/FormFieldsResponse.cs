using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents response of the fields resource
    /// </summary>
    public class FormFieldsResponse : Saaspose.Common.BaseResponse
    {
        public FormFieldsEnvelop Fields { get; set; }

    }
}
