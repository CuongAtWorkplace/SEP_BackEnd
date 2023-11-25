using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class UploadedFile
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public int? ClassId { get; set; }

        public virtual Class? Class { get; set; }
    }
}
