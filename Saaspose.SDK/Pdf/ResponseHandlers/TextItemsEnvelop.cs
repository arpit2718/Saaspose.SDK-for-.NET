using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents container part of the textitems resource response
    /// </summary>
    public class TextItemsEnvelop
    {
 
        public List<LinkResponse> Links { get; set; }
        public List<TextItem> List { get; set; }
    }
}
