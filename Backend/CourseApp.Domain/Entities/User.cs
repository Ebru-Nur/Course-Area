using CourseApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public RoleType Role { get; set; }

        // Navigation Property
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<Cart> CartItems { get; set; } = new HashSet<Cart>();
    }
}
