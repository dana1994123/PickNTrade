using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Store
    {
        public Guid Id { get; set; }
        public String StoreName { get; set; }
        public String PresentationLayer { get; set; }
        public String BusinessLogicLayer { get; set; }

    }
}