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
    public class CourseContentRepository : ICourseContentRepository
    {
        private readonly AppDbContext _context;

        public CourseContentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CourseContent content)
        {
            await _context.CourseContents.AddAsync(content);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CourseContent>> GetContentsByCourseIdAsync(int courseId)
        {
            return await _context.CourseContents
                .Where(c => c.CourseId == courseId)
                .ToListAsync();
        }
    }
}
