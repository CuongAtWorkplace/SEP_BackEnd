using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Notification
    {
        public Notification()
        {
            NotificationUsers = new HashSet<NotificationUser>();
        }

        public int NotificationId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<NotificationUser> NotificationUsers { get; set; }
    }
}
