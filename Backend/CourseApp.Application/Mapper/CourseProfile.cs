using AutoMapper;
using CourseApp.Application.DTOs;
using CourseApp.Domain.Entities;

namespace CourseApp.Application.Mapper
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CourseCreateDto, Course>();
        }
    }
}
