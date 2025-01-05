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
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<string>> AddToCartAsync(CartAddDto cartAddDto, int userId)
        {
            var existingCartItem = await _cartRepository.GetCartItemAsync(userId, cartAddDto.CourseId);
            if (existingCartItem != null)
            {
                return BaseResponse<string>.ErrorResponse("Course is already in the cart.");
            }

            var cart = new Cart
            {
                UserId = userId,
                CourseId = cartAddDto.CourseId
            };

            await _cartRepository.AddToCartAsync(cart);
            return BaseResponse<string>.SuccessResponse("Course added to cart successfully.");
        }

        public async Task<BaseResponse<string>> RemoveFromCartAsync(int cartId, int userId)
        {
            var cartItem = await _cartRepository.GetCartItemsAsync(userId);
            if (cartItem == null)
            {
                return BaseResponse<string>.ErrorResponse("Cart item not found.");
            }

            await _cartRepository.RemoveFromCartAsync(cartId);
            return BaseResponse<string>.SuccessResponse("Course removed from cart successfully.");
        }

        public async Task<BaseResponse<IEnumerable<CartDto>>> GetCartItemsAsync(int userId)
        {
            var cartItems = await _cartRepository.GetCartItemsAsync(userId);
            var cartDtos = _mapper.Map<IEnumerable<CartDto>>(cartItems);
            return BaseResponse<IEnumerable<CartDto>>.SuccessResponse(cartDtos, "Cart items retrieved successfully.");
        }
    }
}
