using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Common
{
    /// <summary>
    /// this class is the base class for every response class
    /// </summary>
    public class BaseResponse
    {
        public BaseResponse() { }

        public string Code { get; set; }
        public string Status { get; set; }
    }
}
