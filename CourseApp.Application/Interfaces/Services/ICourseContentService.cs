using CourseApp.Application.DTOs;
using CourseApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Application.Interfaces.Services
{
    public interface ICourseContentService
    {
        Task<BaseResponse<string>> AddContentAsync(CourseContentCreateDto contentDto);
        Task<BaseResponse<IEnumerable<CourseContentDto>>> GetCourseContentsAsync(int courseId, int userId);
    }
}
