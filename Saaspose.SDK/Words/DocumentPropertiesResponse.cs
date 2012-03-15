using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Words
{
    public class DocumentPropertiesResponse
    {
        public DocumentPropertiesResponse() { }

        /// <summary>
        /// Link Response related to document properties
        /// <link href="http://api.saaspose.com/v1.0/words/TestProperties.doc/documentProperties/Author" rel="self" />
        /// </summary>
        public LinkResponse link { get; set; }

        /// <summary>
        /// Document Property
        /// </summary>
        public List<DocumentProperty> List { get; set; }
    }
}
