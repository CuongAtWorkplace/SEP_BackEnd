using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class NoteTeacher
    {
        public int NoteId { get; set; }
        public int? UserId { get; set; }
        public int? ClassId { get; set; }
        public string? Content { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Class? Class { get; set; }
        public virtual User? User { get; set; }
    }
}
