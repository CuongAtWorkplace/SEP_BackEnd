using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.ResourceModel.ViewModel
{
    public class ReportVM
    {
        public int ReportUserId { get; set; }
        public int? FromUser { get; set; }
        public string? FromAccountName { get; set; }
        public int? ToUser { get; set; }
        public string? ToAccountName { get; set; }
        public string? Description { get; set; }
        public string? CreateDate { get; set; }
        public string? Reason { get; set; }
        public string? EvidenceImage { get; set; }
        public bool? IsChecked { get; set; }
    }
}
