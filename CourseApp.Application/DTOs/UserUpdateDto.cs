using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Application.DTOs
{
    public class UserUpdateDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}
