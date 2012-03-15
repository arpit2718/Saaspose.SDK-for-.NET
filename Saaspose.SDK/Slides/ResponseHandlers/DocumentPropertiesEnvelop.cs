using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Slides
{
    /// <summary>
    /// represents container part of the document properties resource response
    /// </summary>
    public class DocumentPropertiesEnvelop
    {
 
        public List<LinkResponse> Links { get; set; }
        public List<DocumentProperty> List { get; set; }
    }
}
