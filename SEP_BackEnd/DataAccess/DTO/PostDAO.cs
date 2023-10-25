using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class PostDAO
    {
        public int PostId { get; set; }
        public int? CreateBy { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ContentPost { get; set; }
        public int? LikeAmout { get; set; }
        public string? Image { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsActive { get; set; }

    }

    public class CommentDTO
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public int? PostId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
        public int? LikeAmount { get; set; }
        public bool? IsActive { get; set; }
    }
}
