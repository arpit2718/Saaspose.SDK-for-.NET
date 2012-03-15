using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents container part of the images resource response
    /// </summary>
    public class ImagesEnvelop
    {
 
        public List<LinkResponse> Links { get; set; }
        public List<ImageResponse> List { get; set; }
    }
}
