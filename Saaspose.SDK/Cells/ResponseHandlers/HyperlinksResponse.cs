using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    ///  Represents response from the Hyperlinks resource
    /// </summary>
    public class HyperlinksResponse : Saaspose.Common.BaseResponse
    {        
        public LinkResponse link { get; set; }

        public int Count { get; set;}
               
        public List<LinkResponse> HyperlinkList { get; set; }

        public Hyperlink Hyperlink { get; set; }

    }
}
