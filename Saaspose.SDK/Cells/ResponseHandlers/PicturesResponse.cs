using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    ///  Represents response from the Pictures resource
    /// </summary>
    public class PicturesResponse : Saaspose.Common.BaseResponse
    {
        
        public LinkResponse link { get; set; }

        public List<LinkResponse> PictureList { get; set; }

        public Picture Picture { get; set; }

    }
}
