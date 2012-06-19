using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Saaspose.SDK.Slides
{
    public class CustomProperty
    {
        public CustomProperty()
        {
        }

        public CustomProperty(String name, String value)
        {
            Name = name;
            Value = value;
        }

        [XmlElement("Name")]
        public String Name { get; set; }

        [XmlElement("Value")]
        public String Value { get; set; }
    }

    [XmlRoot(ElementName = "DocumentProperties")]
    public class CustomPropertyList
    {
        [XmlElement("DocumentProperty")]
        public List<CustomProperty> Entries { get; set; }
    }

}
