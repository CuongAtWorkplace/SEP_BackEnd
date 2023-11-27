using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Post
    {
        public Post()
        {
            UserCommentPosts = new HashSet<UserCommentPost>();
        }

        public int PostId { get; set; }
        public int? CreateBy { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ContentPost { get; set; }
        public int? LikeAmout { get; set; }
        public string? Image { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsActive { get; set; }

        public virtual User? CreateByNavigation { get; set; }
        public virtual ICollection<UserCommentPost> UserCommentPosts { get; set; }
    }
}
