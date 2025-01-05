using CourseApp.Application.Interfaces.Repositories;
using CourseApp.Domain.Entities;
using CourseApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> SearchAsync(string? name, string? category, decimal? minPrice, decimal? maxPrice)
        {
            return await _context.Courses
                .Where(c =>
                    (string.IsNullOrEmpty(name) || c.Name.Contains(name)) &&
                    (string.IsNullOrEmpty(category) || c.Category == category) &&
                    (!minPrice.HasValue || c.Price >= minPrice.Value) &&
                    (!maxPrice.HasValue || c.Price <= maxPrice.Value))
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }
    }
}
