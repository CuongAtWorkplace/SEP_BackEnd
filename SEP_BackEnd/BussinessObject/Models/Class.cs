using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Class
    {
        public Class()
        {
            ListStudentClasses = new HashSet<ListStudentClass>();
            NoteTeachers = new HashSet<NoteTeacher>();
            QuizzeInClasses = new HashSet<QuizzeInClass>();
            RoomCallVideos = new HashSet<RoomCallVideo>();
            UploadedFiles = new HashSet<UploadedFile>();
        }

        public int ClassId { get; set; }
        public string? ClassName { get; set; }
        public int? TeacherId { get; set; }
        public int? CourseId { get; set; }
        public int? NumberStudent { get; set; }
        public string? Topic { get; set; }
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
        public virtual StatusClass? StatusNavigation { get; set; }
        public virtual User? Teacher { get; set; }
        public virtual ICollection<ListStudentClass> ListStudentClasses { get; set; }
        public virtual ICollection<NoteTeacher> NoteTeachers { get; set; }
        public virtual ICollection<QuizzeInClass> QuizzeInClasses { get; set; }
        public virtual ICollection<RoomCallVideo> RoomCallVideos { get; set; }
        public virtual ICollection<UploadedFile> UploadedFiles { get; set; }
    }
}
