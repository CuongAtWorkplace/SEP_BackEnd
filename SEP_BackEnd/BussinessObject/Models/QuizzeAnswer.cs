using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class QuizzeAnswer
    {
        public int QuizzeAnswerId { get; set; }
        public int? QuestionId { get; set; }
        public string? Answer { get; set; }
        public string? IsCorrect { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Question? Question { get; set; }
    }
}
