using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublisherApi.Models
{
    public class Request
    {
        public string Method { get; set; }
        public dynamic Data { get; set; }
    }
}
