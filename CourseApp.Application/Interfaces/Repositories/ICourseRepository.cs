using CourseApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Application.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Task AddAsync(Course course);
        Task<IEnumerable<Course>> SearchAsync(string? name, string? category, decimal? minPrice, decimal? maxPrice);
        Task<IEnumerable<Course>> GetAllAsync();
    }
}
