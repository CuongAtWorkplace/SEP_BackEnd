using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.ResourceModel.ViewModel
{
    public class APIResponeVM
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public bool IsSucceed { get; set; }
        public object? Data { get; set; }
    }
}
