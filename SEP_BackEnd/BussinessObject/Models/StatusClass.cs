using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class StatusClass
    {
        public StatusClass()
        {
            Classes = new HashSet<Class>();
        }

        public int StatusId { get; set; }
        public string? StatusName { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
