using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class Validation
    {
        public Validation()
        { 
        
        }

        public string AlertStyle { get; set;}
        public List<CellArea> AreaList { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorTitle { get; set; }
        public string Formula1 { get; set; }
        public string Formula2 { get; set; }
        public bool IgnoreBlank { get; set; }
        public bool InCellDropDown { get; set; }
        public string InputMessage { get; set; }
        public string InputTitle { get; set; }
        public string Operator { get; set; }
        public bool ShowError { get; set; }
        public bool ShowInput { get; set; }
        public string Type { get; set; }

    }
}
