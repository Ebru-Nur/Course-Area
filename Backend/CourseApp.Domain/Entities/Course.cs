using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;

        // Navigation Properties
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<Cart> CartItems { get; set; } = new HashSet<Cart>();
        public ICollection<CourseContent> Contents { get; set; } = new HashSet<CourseContent>();
    }
}
