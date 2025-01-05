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
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, CartDto>()
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Course.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Course.Price));
        }
    }
}
