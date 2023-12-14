using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class PaymentHistory
    {
        public int Id { get; set; }
        public int? FromUser { get; set; }
        public int? ToUser { get; set; }
        public int? TotalMoney { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Type { get; set; }

        public virtual User? FromUserNavigation { get; set; }
        public virtual User? ToUserNavigation { get; set; }
    }
}
