using AutoMapper;
using CourseApp.Application.DTOs;
using CourseApp.Application.Interfaces.Repositories;
using CourseApp.Domain.Entities;
using CourseApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public PaymentService(ICartRepository cartRepository, IPaymentRepository paymentRepository, IOrderRepository orderRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<string>> ProcessPaymentAsync(int userId)
        {
            var cartItems = await _cartRepository.GetCartItemsAsync(userId);

            if (!cartItems.Any())
            {
                return BaseResponse<string>.ErrorResponse("Cart is empty.");
            }

            var totalAmount = cartItems.Sum(c => c.Course.Price);

            var payment = new Payment
            {
                UserId = userId,
                Amount = totalAmount,
                PaymentMethod = "Credit Card" // Example method
            };

            await _paymentRepository.AddPaymentAsync(payment);

            foreach (var cartItem in cartItems)
            {
                var order = new Order
                {
                    UserId = userId,
                    CourseId = cartItem.CourseId
                };
                await _orderRepository.AddOrderAsync(order);
                await _cartRepository.RemoveFromCartAsync(cartItem.Id);
            }

            return BaseResponse<string>.SuccessResponse("Payment processed successfully.");
        }

        public async Task<BaseResponse<IEnumerable<PaymentDto>>> GetPaymentHistoryAsync(int userId)
        {
            var payments = await _paymentRepository.GetPaymentsByUserIdAsync(userId);
            var paymentDtos = _mapper.Map<IEnumerable<PaymentDto>>(payments);
            return BaseResponse<IEnumerable<PaymentDto>>.SuccessResponse(paymentDtos, "Payment history retrieved successfully.");
        }
    }
}
