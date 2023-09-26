using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Question
    {
        public Question()
        {
            QuizzeAnswers = new HashSet<QuizzeAnswer>();
        }

        public int QuestionId { get; set; }
        public int? QuizzeId { get; set; }
        public string? Question1 { get; set; }
        public string? Answer { get; set; }
        public bool? IsMultiQuestion { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Quizze? Quizze { get; set; }
        public virtual ICollection<QuizzeAnswer> QuizzeAnswers { get; set; }
    }
}
