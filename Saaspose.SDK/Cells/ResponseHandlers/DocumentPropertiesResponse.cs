using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    ///  Represents response from the Document Properties resource
    /// </summary>
    public class DocumentPropertiesResponse 
    {
        public DocumentPropertiesResponse() { }
               
        public LinkResponse Link { get; set; }

        /// <summary>
        /// Document Property
        /// </summary>
        public List<DocumentProperty> DocumentPropertyList { get; set; }
    }
}
