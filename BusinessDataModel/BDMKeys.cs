using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDataModel
{
    public class Result
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
