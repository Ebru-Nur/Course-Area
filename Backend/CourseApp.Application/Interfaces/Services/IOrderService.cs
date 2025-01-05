using CourseApp.Application.DTOs;
using CourseApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<BaseResponse<IEnumerable<OrderDto>>> GetOrderHistoryAsync(int userId);
    }
}
