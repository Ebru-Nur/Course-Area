using CourseApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Application.Interfaces.Repositories
{
    public interface ICourseContentRepository
    {
        Task AddAsync(CourseContent content);
        Task<IEnumerable<CourseContent>> GetContentsByCourseIdAsync(int courseId);
    }
}
