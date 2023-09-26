using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class NotificationUser
    {
        public int NotificationUserId { get; set; }
        public int? UserId { get; set; }
        public int? NotificationId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? Content { get; set; }
        public bool? IsReaded { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Notification? Notification { get; set; }
        public virtual User? User { get; set; }
    }
}
