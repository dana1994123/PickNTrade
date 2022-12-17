using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Questions
    {
        public Guid Id { get; set; }
        public String UserName { get; set; }
        public String QuestionDescription { get; set; }
        
    }
}