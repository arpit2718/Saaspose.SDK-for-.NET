using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents response of a single form field
    /// </summary>
    public class FormFieldResponse : Saaspose.Common.BaseResponse
    {
        public FormField Field { get; set; }

    }
}
