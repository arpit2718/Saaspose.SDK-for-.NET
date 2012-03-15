using System;
using System.Collections.Generic;
using System.Text;
using Saaspose.Common;

namespace Saaspose.BarCode
{
    public class RecognitionResponse : BaseResponse
    {
        //public RecognitionEnvelop Barcodes { get; set; }
        public List<RecognizedBarCode> Barcodes { get; set; }
    }
}
