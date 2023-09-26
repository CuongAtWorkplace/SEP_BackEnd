using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class QuizzeResult
    {
        public int QuizzeResultId { get; set; }
        public int? QuizzeId { get; set; }
        public int? UserId { get; set; }
        public int? Score { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? NumberOfTrue { get; set; }
        public int? NumberOfFalse { get; set; }

        public virtual Quizze? Quizze { get; set; }
        public virtual User? User { get; set; }
    }
}
