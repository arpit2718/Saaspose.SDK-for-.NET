using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Slides
{
    /// <summary>
    /// represents response of the slides resource
    /// </summary>
    public class SlidesResponse : Saaspose.Common.BaseResponse
    {

        public SlidesEnvelop Slides { get; set; }
                
    }

    
}
