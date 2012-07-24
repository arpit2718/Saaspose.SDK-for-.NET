using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Saaspose.Words
{
    public class DocumentEntry
    {
        public DocumentEntry()
        {
        }

        public DocumentEntry(String href, String importFormatMode)
        {
            Href = href;
            ImportFormatMode = importFormatMode;
        }

        [XmlAttribute(AttributeName = "href")]
        public String Href { get; set; }

        [XmlAttribute(AttributeName = "importFormatMode")]
        public String ImportFormatMode { get; set; }
    }

    [XmlRoot(ElementName = "documents")]
    public class DocumentEntryList
    {
        [XmlElement("document")]
        public List<DocumentEntry> DocumentEntries { get; set; }
    }
}
