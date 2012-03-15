using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Slides
{
    /// <summary>
    /// represents response of the slides resource
    /// </summary>
    public class TextItemsResponse : Saaspose.Common.BaseResponse
    {

        public TextItemsEnvelop TextItems { get; set; }
                
    }

    
}
