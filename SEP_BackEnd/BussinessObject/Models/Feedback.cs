using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Feedback
    {
        public Feedback()
        {
            Users = new HashSet<User>();
        }

        public int FeedbackId { get; set; }
        public int FromUserId { get; set; }
        public int? Rating { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifileDate { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
