using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class ReportUser
    {
        public int ReportUserId { get; set; }
        public int? FromUser { get; set; }
        public int ToUser { get; set; }
        public string? Description { get; set; }
        public string? Reason { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Status { get; set; }
        public DateTime? Modified { get; set; }
        public string? EvidenceImage { get; set; }
        public bool? IsChecked { get; set; }

        public virtual User? FromUserNavigation { get; set; }
    }
}
