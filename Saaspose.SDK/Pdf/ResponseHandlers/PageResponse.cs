using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents page part of the Pages resource response
    /// </summary>
    public class PageResponse
    {
      
        public List<LinkResponse> Links { get; set; }
        public int Id { get; set; }
        public string Images { get; set; }

    }
}
