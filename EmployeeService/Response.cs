using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    public class Response<T> : ResponseBase
    {
        public T Data { get; set; }
    }

    public class ResponseBase
    {
        public HttpStatusCode ResponseСode { get; set; }

        public bool Success { get; set; }

        public List<string> Errors { get; set; }

        public ResponseBase()
        {
            Errors = new List<string>();
            Success = true;
        }
    }
}
