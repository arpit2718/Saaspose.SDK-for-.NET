using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents page part of the Pages resource response
    /// </summary>
    public class ImageResponse
    {
      
        public List<LinkResponse> Links { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

    }
}
