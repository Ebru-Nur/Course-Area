using CourseApp.Application.DTOs;
using CourseApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Application.Interfaces.Services
{
    public interface ICartService
    {
        Task<BaseResponse<string>> AddToCartAsync(CartAddDto cartAddDto, int userId);
        Task<BaseResponse<string>> RemoveFromCartAsync(int cartId, int userId);
        Task<BaseResponse<IEnumerable<CartDto>>> GetCartItemsAsync(int userId);
    }
}
