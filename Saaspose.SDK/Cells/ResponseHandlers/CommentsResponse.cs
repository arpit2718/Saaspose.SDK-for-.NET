using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Cells
{
    /// <summary>
    ///  Represents response from the Comments resource
    /// </summary>
    public class CommentsResponse : Saaspose.Common.BaseResponse
    {        
        public LinkResponse link { get; set; }

        public List<LinkResponse> CommentList { get; set; }

        public Comment Comment { get; set; }
    }
}
