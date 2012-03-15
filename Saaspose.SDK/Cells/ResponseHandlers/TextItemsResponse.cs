using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    ///  Represents response from the TextItems resource
    /// </summary>
    public class TextItemsResponse
    {
        public TextItemsResponse() { }
       
        public LinkResponse link { get; set; }
     
        public List<TextItem> TextItemList { get; set; }
    }
}
