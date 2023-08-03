using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RedarborTechnicalTest.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public List<string> Errors { get; set; }
        public string ErrorMessage { get; set; }
        public HttpStatusCode CodeResponse { get; set; }
        public BusinessException()
        {
        }
    }
}
