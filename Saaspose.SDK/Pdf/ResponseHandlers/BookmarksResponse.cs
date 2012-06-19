using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
 
   /// <summary>
    /// represents response from the Bookmarks resource
    /// </summary>
    public class BookmarksResponse : Saaspose.Common.BaseResponse
    {
        public BookmarksEnvelop Bookmarks { get; set; }

    }
}
