using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents response of the Pages resource
    /// </summary>
    public class PagesResponse : Saaspose.Common.BaseResponse
    {
        
        public PagesEnvelop Pages { get; set; }
                
    }

    
}
