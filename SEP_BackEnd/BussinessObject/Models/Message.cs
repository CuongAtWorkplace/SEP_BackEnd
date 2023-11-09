using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int? ChatRoomId { get; set; }
        public int? CreateBy { get; set; }
        public string? Content { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Photo { get; set; }

        public virtual ChatRoom? ChatRoom { get; set; }
        public virtual User? CreateByNavigation { get; set; }
    }
}
