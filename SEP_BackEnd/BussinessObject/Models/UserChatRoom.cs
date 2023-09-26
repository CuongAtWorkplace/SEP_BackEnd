using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class UserChatRoom
    {
        public int UserChatRoomId { get; set; }
        public int? UserId { get; set; }
        public int? ChatRoomId { get; set; }

        public virtual ChatRoom? ChatRoom { get; set; }
        public virtual User? User { get; set; }
    }
}
