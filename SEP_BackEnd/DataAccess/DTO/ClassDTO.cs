using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class ClassDTO
    {
        public int ClassId { get; set; }
        public string? ClassName { get; set; }
        public int? TeacherId { get; set; }
        public string? TeacherName { get; set; }
        public int? CourseId { get; set; }
        public string? CourseName { get; set; }
        public int? NumberStudent { get; set; }
        public string? Topic { get; set; }
        public int? QuizzeId { get; set; }
        public string? QuizzeName { get; set; }
        public string? Schedule { get; set; }
        public string? Fee { get; set; }
        public string? NumberOfWeek { get; set; }
        public string? NumberPhone { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }
        public bool? IsDelete { get; set; }
        public string? TokenClass { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Quizze? Quizze { get; set; }
        public virtual User? Teacher { get; set; }
    }

    public class EditClassDTO
    {
        public int ClassId { get; set; }
        public string? ClassName { get; set; }
        public string? Topic { get; set; }
        public int? QuizzeId { get; set; }
        public string? Schedule { get; set; }
        public string? Fee { get; set; }
        public string? NumberOfWeek { get; set; }
        public string? NumberPhone { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class ClassAllDAO
    {
        public string? ClassName { get; set; }
        public string? TeacherName { get; set; }
        public string? CourseName { get; set; }
        public int? NumberStudent { get; set; }
        public string? Topic { get; set; }
        public int? QuizzeId { get; set; }
        public string? QuizzeName { get; set; }
        public string? Schedule { get; set; }
        public string? Fee { get; set; }
        public string? NumberOfWeek { get; set; }
        public string? NumberPhone { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }
    }
}
