using CourseApp.Application.DTOs;
using CourseApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddCourse(CourseCreateDto courseCreateDto)
        {
            //var instructorId = int.Parse(User.FindFirst("id")!.Value);
            var response = await _courseService.AddCourseAsync(courseCreateDto, 1);
            return response.Success ? Ok(response) : Unauthorized(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCourses([FromQuery] CourseSearchDto courseSearchDto)
        {
            var response = await _courseService.SearchCoursesAsync(courseSearchDto);
            return Ok(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCourses()
        {
            var response = await _courseService.GetAllCoursesAsync();
            return Ok(response);
        }
    }
}
