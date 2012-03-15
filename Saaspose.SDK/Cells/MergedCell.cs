using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
   public class MergedCell
    {
        public MergedCell()
        { 
        }

        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public int StartColumn { get; set; }
        public int EndColumn { get; set; }
    }
}
