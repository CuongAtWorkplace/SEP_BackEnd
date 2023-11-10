using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class NotificationDTO
    {
        public int NotificationUserId { get; set; }
        public int? UserId { get; set; }
        public int? NotificationId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? Content { get; set; }
        public bool? IsReaded { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Notification? Notification { get; set; }
        public virtual User? User { get; set; }
    }
}
