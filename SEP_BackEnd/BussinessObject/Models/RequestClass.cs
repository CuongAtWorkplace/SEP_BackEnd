using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class RequestClass
    {
        public int RequestClassId { get; set; }
        public int? UserId { get; set; }
        public int? ClassId { get; set; }
        public bool? Type { get; set; }

        public virtual Class? Class { get; set; }
        public virtual User? User { get; set; }
    }
}
