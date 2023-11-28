using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class NoteDTO
    {
        public int NoteId { get; set; }
        public int? UserId { get; set; }
        public int? ClassId { get; set; }
        public string? Content { get; set; }
    }
}
