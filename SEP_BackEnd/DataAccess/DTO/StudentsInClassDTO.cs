using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public partial class StudentsInClassDTO
    {
        public int ListStudentInClassId { get; set; }
        public int? ClassId { get; set; }
        public int? UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Class? Class { get; set; }
        public virtual User? User { get; set; }
    }
}
