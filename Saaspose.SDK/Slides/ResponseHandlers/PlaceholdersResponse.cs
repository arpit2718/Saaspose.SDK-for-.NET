using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Slides;

namespace Saaspose.SDK.Slides.ResponseHandlers
{
    public class PlaceholdersResponse : Saaspose.Common.BaseResponse
    {
        public PlaceholdersEnvelop Placeholders { get; set; }

    }
}
