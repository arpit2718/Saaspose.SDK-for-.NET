﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    ///  Represents response from the calculateformula resource
    /// </summary>
    public class CalcualteFormulaResponse : Saaspose.Common.BaseResponse
    {

        public ValueResponse Value { get; set; }

    }
}
