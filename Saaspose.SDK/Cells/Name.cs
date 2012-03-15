using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class Name
    {
        public Name()
        { 
        }

        public LinkResponse link { get; set; }

        public string Comment { get; set;}
        public string WorksheetName { get; set; }
        public string IsReferred { get; set; }
        public string IsVisible { get; set; }
        public string R1C1RefersTo { get; set; }
        public string RefersTo { get; set; }
        public string Text { get; set; }

    }
}
