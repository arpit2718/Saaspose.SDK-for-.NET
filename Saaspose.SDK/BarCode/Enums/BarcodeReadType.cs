using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.BarCode
{
    /// <summary>
    /// All supported types for reading barcodes.
    /// </summary>
    public enum BarCodeReadType
    {
        AllSupportedTypes, 
        AustraliaPost, 
        Aztec, 
        BooklandEAN, 
        Codabar, 
        Code11, 
        Code128, 
        Code39Extended, 
        Code39Standard,
        Code93Extended, 
        Code93Standard, 
        DataBar, 
        DataBarLimited, 
        DataMatrix, 
        DeutschePostIdentcode,
        DeutschePostLeitcode, 
        EAN128, 
        EAN13, 
        EAN14, 
        EAN8, 
        Empty, 
        IATA2of5, 
        ITF14, 
        ITF6, 
        Interleaved2of5,
        ItalianPost25, 
        MSI, 
        MacroPdf417, 
        Matrix2of5, 
        OPC, 
        OneCode, 
        PZN, 
        PatchCode, 
        Pdf417, 
        Planet, 
        Postnet,
        QR, 
        RM4SCC, 
        SSCC18, 
        Standard2of5, 
        Supplement, 
        UPCA, 
        UPCE, 
        VIN
    }
}
