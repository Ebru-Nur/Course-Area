using CourseApp.Application.DTOs;
using CourseApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Application.Interfaces.Repositories
{
    public interface IPaymentService
    {
        Task<BaseResponse<string>> ProcessPaymentAsync(int userId);
        Task<BaseResponse<IEnumerable<PaymentDto>>> GetPaymentHistoryAsync(int userId);
    }
}
