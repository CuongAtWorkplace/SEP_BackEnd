using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Quizze
    {
        public Quizze()
        {
            Classes = new HashSet<Class>();
            Questions = new HashSet<Question>();
            QuizzeResults = new HashSet<QuizzeResult>();
        }

        public int QuizzeId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? CreateBy { get; set; }
        public string? WorkingTime { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifiedBy { get; set; }
        public int? NumberOfQuestion { get; set; }
        public string? QuizzeCategory { get; set; }
        public bool? IsDraft { get; set; }
        public bool? IsDelete { get; set; }

        public virtual User? CreateByNavigation { get; set; }
        public virtual User? ModifiedByNavigation { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<QuizzeResult> QuizzeResults { get; set; }
    }
}
