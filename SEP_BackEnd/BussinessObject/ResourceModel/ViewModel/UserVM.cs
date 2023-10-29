using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.ResourceModel.ViewModel
{
    public class UserVM
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public string? Status { get; set; }
    }
}
