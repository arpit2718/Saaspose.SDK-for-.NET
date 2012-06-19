using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Words
{
    public class MergeFieldResponse : Saaspose.Common.BaseResponse
    {
        public FieldNames FieldNames { get; set; }
    }

    public class FieldNames
    {
        public List<string> Names { get; set; }
        public LinkResponse link { get; set; }
    }

}
