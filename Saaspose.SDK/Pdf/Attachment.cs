using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents a single attachment in document
    /// </summary>    
    
    public class Attachment
    {
        public Attachment() { }

      //  public List<LinkResponse> Links { get; set; }
        public Color Color { get; set; }
        public string MimeType { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public string ModificationDate { get; set; }
        public Int32 Size { get; set; }
      
    }
}
