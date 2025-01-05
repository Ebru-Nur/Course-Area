using CourseApp.Application.DTOs;
using CourseApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseContentController : ControllerBase
    {
        private readonly ICourseContentService _contentService;

        public CourseContentController(ICourseContentService contentService)
        {
            _contentService = contentService;
        }

        [Authorize(Roles = "Instructor")]
        [HttpPost("add")]
        public async Task<IActionResult> AddContent(CourseContentCreateDto contentDto)
        {
            var response = await _contentService.AddContentAsync(contentDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [Authorize]
        [HttpGet("{courseId}/contents")]
        public async Task<IActionResult> GetCourseContents(int courseId)
        {
            var userId = int.Parse(User.FindFirst("id")!.Value);
            var response = await _contentService.GetCourseContentsAsync(courseId, userId);
            return response.Success ? Ok(response) : Forbid(response.Message);
        }
    }
}
