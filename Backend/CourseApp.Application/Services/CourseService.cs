using AutoMapper;
using CourseApp.Application.DTOs;
using CourseApp.Application.Interfaces.Repositories;
using CourseApp.Application.Interfaces.Services;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Enums;
using CourseApp.Shared.Constants;
using CourseApp.Shared.Responses;

namespace CourseApp.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IUserRepository userRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CourseDto>> AddCourseAsync(CourseCreateDto courseCreateDto, int instructorId)
        {
            var instructor = await _userRepository.GetByIdAsync(instructorId);
            if (instructor == null || instructor.Role != RoleType.Instructor)
            {
                return BaseResponse<CourseDto>.ErrorResponse(Message.Common.YETKISIZ_ERISIM);
            }

            var course = _mapper.Map<Course>(courseCreateDto);
            await _courseRepository.AddAsync(course);

            var courseDto = _mapper.Map<CourseDto>(course);
            return BaseResponse<CourseDto>.SuccessResponse(courseDto, Message.Course.KAYIT_BASARILI);
        }

        public async Task<BaseResponse<IEnumerable<CourseDto>>> SearchCoursesAsync(CourseSearchDto courseSearchDto)
        {
            var courses = await _courseRepository.SearchAsync(courseSearchDto.Name, courseSearchDto.Category, courseSearchDto.MinPrice, courseSearchDto.MaxPrice);
            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);

            return BaseResponse<IEnumerable<CourseDto>>.SuccessResponse(courseDtos, Message.Common.VERI_GETIRILDI);
        }

        public async Task<BaseResponse<IEnumerable<CourseDto>>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);

            return BaseResponse<IEnumerable<CourseDto>>.SuccessResponse(courseDtos, Message.Common.VERI_GETIRILDI);
        }
    }
}
