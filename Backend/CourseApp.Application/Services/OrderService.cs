using AutoMapper;
using CourseApp.Application.DTOs;
using CourseApp.Application.Interfaces.Repositories;
using CourseApp.Application.Interfaces.Services;
using CourseApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<OrderDto>>> GetOrderHistoryAsync(int userId)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return BaseResponse<IEnumerable<OrderDto>>.SuccessResponse(orderDtos, "Order history retrieved successfully.");
        }
    }
}
