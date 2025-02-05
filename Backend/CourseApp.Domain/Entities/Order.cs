﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        // Navigation Properties
        public User User { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
