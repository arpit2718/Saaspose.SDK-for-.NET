using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Words
{
    class ReplaceTextResponse
    {
            public int Code { get; set; }
            public string Status { get; set; }
            public int Matches { get; set; }
            public LinkResponse DocumentLink { get; set; }
    }
}
