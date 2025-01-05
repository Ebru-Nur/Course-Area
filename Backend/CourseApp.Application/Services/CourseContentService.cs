using AutoMapper;
using CourseApp.Application.DTOs;
using CourseApp.Application.Interfaces.Repositories;
using CourseApp.Application.Interfaces.Services;
using CourseApp.Domain.Entities;
using CourseApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Application.Services
{
    public class CourseContentService : ICourseContentService
    {
        private readonly ICourseContentRepository _contentRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CourseContentService(ICourseContentRepository contentRepository, IOrderRepository orderRepository, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<string>> AddContentAsync(CourseContentCreateDto contentDto)
        {
            var content = _mapper.Map<CourseContent>(contentDto);
            await _contentRepository.AddAsync(content);
            return BaseResponse<string>.SuccessResponse("Course content added successfully.");
        }

        public async Task<BaseResponse<IEnumerable<CourseContentDto>>> GetCourseContentsAsync(int courseId, int userId)
        {
            //var orderExists = await _orderRepository.GetOrdersByUserIdAsync(userId)
            //    .AnyAsync(o => o.CourseId == courseId);
            var orderExists = false;


            if (!orderExists)
            {
                return BaseResponse<IEnumerable<CourseContentDto>>.ErrorResponse("You must purchase the course to access its contents.");
            }

            var contents = await _contentRepository.GetContentsByCourseIdAsync(courseId);
            var contentDtos = _mapper.Map<IEnumerable<CourseContentDto>>(contents);
            return BaseResponse<IEnumerable<CourseContentDto>>.SuccessResponse(contentDtos, "Course contents retrieved successfully.");
        }
    }
}
