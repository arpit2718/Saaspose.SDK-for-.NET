using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents response of a single Bookmark
    /// </summary>
    public class BookmarkResponse : Saaspose.Common.BaseResponse
    {
        public BookmarkResponse() { }

        public Bookmark  Bookmark { get; set; }

    }
}
