using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    ///  Represents response from the Names resource
    /// </summary>
    public class NamesResponse : Saaspose.Common.BaseResponse
    {
       
        public LinkResponse link { get; set; }

        public int Count { get; set; }

        public List<Name> NameList { get; set; }
    }
}
