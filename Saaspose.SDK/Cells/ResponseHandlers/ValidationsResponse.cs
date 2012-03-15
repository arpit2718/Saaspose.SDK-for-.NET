using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    ///  Represents response from the Validations resource
    /// </summary>
    public class ValidationsResponse : Saaspose.Common.BaseResponse
    {       
        public LinkResponse link { get; set; }

        public int Count { get; set; }
            
        public List<LinkResponse> ValidationList { get; set; }

        public Validation Validation { get; set; }

    }
}
