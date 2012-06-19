using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class Cell
    {
        /// <summary>
        /// Cell Class Default Constructor
        /// </summary>
        public Cell()
        {
            
        }
       
        public LinkResponse link { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Value { get; set; }
        public string Formula { get; set; }
        public bool IsFormula { get; set; }
        public bool IsMerged { get; set; }       

    }
}
