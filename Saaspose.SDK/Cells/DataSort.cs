using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class DataSort
    {
        public DataSort()
        { 
        
        }

        public bool CaseSensitive { get; set; }
        public bool HasHeaders { get; set; }
        public bool SortLeftToRight { get; set; }
        public List <SortKey> KeyList { get; set; }

    }
}
