using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Slides
{
    /// <summary>
    /// represents page part of the Pages resource response
    /// </summary>
    public class ImageResponse
    {

        public UriResponse ParentUri { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

    }
}
