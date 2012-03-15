using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Words
{

    /// <summary>
    /// Status code of file conversion  
    /// </summary>
    public enum ConversionStatus { OK = 0, Unknown }

    /// <summary>
    /// Represents supported conversion types
    /// </summary>
    public enum SaveFormat
    {
        Doc,
        Dot,
        Docx,
        Docm,
        Dotx,
        Dotm,
        FlatOpc,
        Rtf,
        WordML,
        Pdf,
        odt,
        ott,
        txt,
        mhtml,
        epub,
        xps,
        swf,
        tiff
    }
}

