using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Profile
    {
        public Guid Id { get; set; }

        public String Name { get; set; }
        public String Bio { get; set; }
        public String Email { get; set; }
        public String Mobile { get; set; }
        public String Avatar { get; set; }

        public String PhoneNumber { get; set; }

        public String FacebookLink { get; set; }
        public String LinkinLink { get; set; }
        public String InstaLink { get; set; }

        public List<Product> MyListingProduct { get; set; }
    }
}