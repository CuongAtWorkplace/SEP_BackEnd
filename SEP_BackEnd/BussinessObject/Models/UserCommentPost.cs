using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class UserCommentPost
    {
        public int UserCommentPostId { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }
        public string? Content { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? LikeAmount { get; set; }
        public bool? IsActive { get; set; }

        public virtual Post? Post { get; set; }
        public virtual User? User { get; set; }
    }
}
