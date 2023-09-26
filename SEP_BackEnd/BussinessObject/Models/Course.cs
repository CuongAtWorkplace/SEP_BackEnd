using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Course
    {
        public Course()
        {
            Classes = new HashSet<Class>();
        }

        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Image { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
