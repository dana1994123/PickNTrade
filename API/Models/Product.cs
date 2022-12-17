using API.Models;

namespace API.Services
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double PointCost { get; set; }
        public String Image{get;set;} 
        public String Owner { get; set; }
        public List<Questions> Questions { get; set; }
        public List<Request> Requests { get; set; }
    }
}


