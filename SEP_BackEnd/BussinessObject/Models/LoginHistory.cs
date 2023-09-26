using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class LoginHistory
    {
        public int LoginHistory1 { get; set; }
        public int? UserId { get; set; }
        public DateTime? TimeLog { get; set; }

        public virtual User? User { get; set; }
    }
}
