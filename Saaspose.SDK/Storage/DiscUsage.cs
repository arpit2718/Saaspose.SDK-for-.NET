using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Storage
{
    /// <summary>
    /// represents DiscUsage section of the Disc response
    /// </summary>
    public class DiscUsage
    {
        public long TotalSize { get; set; }
        public long UsedSize { get; set; }
    }
}
