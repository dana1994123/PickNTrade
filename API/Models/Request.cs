using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Request
    {
        public Guid Id { get; set; }
        public String UserName { get; set; }
        public Boolean IsAccepted { get; set; }
    }
}