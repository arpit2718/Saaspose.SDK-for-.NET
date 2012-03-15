using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents container part of the Pages resource response
    /// </summary>
    public class PagesEnvelop
    {
 
        public List<LinkResponse> Links { get; set; }
        public List<PageResponse> List { get; set; }
    }
}
