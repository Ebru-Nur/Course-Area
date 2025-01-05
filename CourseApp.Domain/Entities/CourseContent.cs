using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Domain.Entities
{
    public class CourseContent
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ContentUrl { get; set; } = string.Empty; // Video veya belge URL'si

        // Navigation Property
        public Course Course { get; set; } = null!;
    }
}
