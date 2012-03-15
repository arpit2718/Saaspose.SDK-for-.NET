using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class Hyperlink
    {
        public Hyperlink()
        {

        }

        public string Address { get; set; }
        public CellArea Area { get; set; }
        public string ScreenTip { get; set; }
        public string TextToDisplay { get; set; }

    }
}
