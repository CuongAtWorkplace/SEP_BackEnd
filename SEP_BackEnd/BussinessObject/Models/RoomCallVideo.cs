using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class RoomCallVideo
    {
        public int RoomId { get; set; }
        public string? RoomName { get; set; }
        public int? TeacherId { get; set; }
        public int? ClassId { get; set; }

        public virtual Class? Class { get; set; }
        public virtual User? Teacher { get; set; }
    }
}
