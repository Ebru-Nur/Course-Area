using CourseApp.Application.DTOs;
using CourseApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Application.Interfaces.Services
{
    public interface ICourseService
    {
        Task<BaseResponse<CourseDto>> AddCourseAsync(CourseCreateDto courseCreateDto, int instructorId);
        Task<BaseResponse<IEnumerable<CourseDto>>> SearchCoursesAsync(CourseSearchDto courseSearchDto);
        Task<BaseResponse<IEnumerable<CourseDto>>> GetAllCoursesAsync();
    }
}
