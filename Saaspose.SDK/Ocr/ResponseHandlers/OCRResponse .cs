﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.OCR 
{
    public class OCRResponse : Saaspose.Common.BaseResponse
    {
        public OCREnvelop PartsInfo { get; set; }
        public string Text { get; set; }
    }
}
