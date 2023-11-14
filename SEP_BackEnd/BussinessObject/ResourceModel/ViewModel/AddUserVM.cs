using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.Models;

namespace BussinessObject.ResourceModel.ViewModel
{
    public class AddUserVM
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string? RoleName { get; set; }
        public string? Address { get; set; }
    }
}
