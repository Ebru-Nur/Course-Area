using AutoMapper;
using CourseApp.Application.DTOs;
using CourseApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Application.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // CreateMap<Entity, DTO>
            CreateMap<User, UserDto>();

            // Optionally add reverse mapping if needed
            // CreateMap<UserDto, User>();
        }
    }
}
