using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class RequestManager
    {
        public int RequestManagerId { get; set; }
        public int? FromUserId { get; set; }
        public int? RoomChatId { get; set; }
        public bool? IsChecked { get; set; }
        public bool? Status { get; set; }
    }
}
