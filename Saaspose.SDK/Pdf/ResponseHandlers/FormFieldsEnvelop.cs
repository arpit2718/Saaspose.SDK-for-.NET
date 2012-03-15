using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents container part of the Pages resource response
    /// </summary>
    public class FormFieldsEnvelop
    {
 
        public List<LinkResponse> Links { get; set; }
        public List<FormField> List { get; set; }
    }
}
