using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class ChatRoom
    {
        public ChatRoom()
        {
            Messages = new HashSet<Message>();
            UserChatRooms = new HashSet<UserChatRoom>();
        }

        public int ChatRoomId { get; set; }
        public string? ChatRoomName { get; set; }
        public string? Description { get; set; }
        public bool? IsManagerChat { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserChatRoom> UserChatRooms { get; set; }
    }
}
