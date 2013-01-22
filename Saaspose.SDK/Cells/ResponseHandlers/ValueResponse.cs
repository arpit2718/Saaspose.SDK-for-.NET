using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    ///  Represents response from the calculateformula resource
    /// </summary>
    public class ValueResponse : Saaspose.Common.BaseResponse
    {
        public int ValueType { get; set; }

        public string Value { get; set; }

    }
}
