using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class Row
    {
        /// <summary>
        /// Row Class Default Constructor
        /// </summary>
        public Row()
        {
            
        }
       
        public LinkResponse link { get; set; }
        public string Index { get; set; }
        public int GroupLevel { get; set; }
        public double Height { get; set; }
        public bool IsHidden { get; set; }
        public bool IsBlank { get; set; }
        public bool IsHeightMatched { get; set; }       

    }
}
