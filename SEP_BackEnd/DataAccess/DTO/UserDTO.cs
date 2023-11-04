using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? RoleId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string RoleName { get; set; }
    }

    public class EditUserDTO
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
    }

    public class ChangePasswordDTO
    {
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? NewPassword { get; set; }
        public string? RePassword { get; set; }
    }
}
