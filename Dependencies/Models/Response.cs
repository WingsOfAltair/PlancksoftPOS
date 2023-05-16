using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependencies.Models
{
    public class Response
    {
        public Response(object ResponseMessage, bool ResponseStatus) { 
            this.ResponseMessage = ResponseMessage;
            this.ResponseStatus = ResponseStatus;
        }
        public object ResponseMessage { get; set; }
        public bool ResponseStatus { get; set; }
    }
}
