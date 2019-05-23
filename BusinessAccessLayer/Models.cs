using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer
{
    public class Result
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public string Color { get; set; }
        public bool Status { get; set; }
    }
    public class QueryTypes
    {
        public int Get = 1;
        public int Post = 2;
        public int Put = 3;
        public int Delete = 4;
    }
    
}
