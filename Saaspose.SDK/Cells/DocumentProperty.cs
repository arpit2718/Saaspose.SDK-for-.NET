using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class DocumentProperty
    {
        public DocumentProperty()
        {
        }

        public DocumentProperty(string propName, string propValue)
        {
            Name = propName;
            Value = propValue;
        }

        public LinkResponse Link { get; set; }
        public string Name { get; set;}
        public string Value{ get; set;}
        public bool BuiltIn { get; set; }

    }
}
