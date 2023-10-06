using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class QuizzeInClass
    {
        public int QuizzeInClass1 { get; set; }
        public int? ClassId { get; set; }
        public int? QuizzeId { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Class? Class { get; set; }
        public virtual Quizze? Quizze { get; set; }
    }
}
