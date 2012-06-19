using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saaspose.Cells
{
    public class Column
    {
        /// <summary>
        /// Column Class Default Constructor
        /// </summary>
        public Column()
        {
            
        }
       
        public LinkResponse link { get; set; }
        public string Index { get; set; }
        public int GroupLevel { get; set; }
        public double Width { get; set; }
        public bool IsHidden { get; set; }       

    }
}
