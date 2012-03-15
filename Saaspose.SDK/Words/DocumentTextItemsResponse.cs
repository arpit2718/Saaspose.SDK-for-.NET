using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Words
{
    public class DocumentTextItemsResponse 
    {
        public DocumentTextItemsResponse() { }

        /// <summary>
        /// Link Response related to document text
        /// <link href="http://api.saaspose.com/v1.0/words/TestTextItems.doc/textItems" rel="self" />
        /// </summary>
        public LinkResponse link { get; set; }

        /// <summary>
        /// TextItem of document
        /// </summary>
        public List<Paragraph> List { get; set; }

    }
}
