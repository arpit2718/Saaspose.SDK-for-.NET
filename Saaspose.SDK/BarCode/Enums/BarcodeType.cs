using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.BarCode
{
    /// <summary>
    /// All supported types for generating barcodes.
    /// </summary>
    public enum BarCodeType
    {
        Codabar, 
        Code11, 
        Code128, 
        Code39Extended, 
        Code93Extended, 
        Interleaved2of5, 
        Code39Standard,
        Code93Standard, 
        MSI, 
        Standard2of5, 
        DataMatrix, 
        GS1DataMatrix, 
        EAN13, 
        EAN8, 
        ITF14, 
        Pdf417,
        Planet, 
        Postnet, 
        QR, 
        UPCA, 
        UPCE, 
        BooklandEAN, 
        EAN128, 
        Aztec, 
        MacroPdf417, 
        Patch, 
        EAN14,
        SSCC18, 
        OneCode, 
        AustraliaPost, 
        RM4SCC, 
        Matrix2of5, 
        DeutschePostIdentcode, 
        PZN, 
        ItalianPost25,
        IATA2of5, 
        VIN, 
        DeutschePostLeitcode, 
        OPC, 
        ITF6, 
        AustralianPosteParcel
    }
}
