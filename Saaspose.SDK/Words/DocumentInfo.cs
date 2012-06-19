using System;
using System.Collections.Generic;
using System.Text;
namespace Saaspose.Words
{
    public class DocumentInfo
    {
        public DocumentInfo() { }
        /// <summary>
        /// document name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The original format of the file.
        /// </summary>
        public string SourceFormat { get; set; }

        /// <summary>
        /// Returns true if the document is encrypted and requires a password to open
        /// </summary>
        public string IsEncrypted { get; set; }

        /// <summary>
        /// Returns true if the document contains a digital signature.
        /// </summary>
        public string IsSigned { get; set; }

        /// <summary>
        /// Document Properties Response
        /// </summary>

    }
}
