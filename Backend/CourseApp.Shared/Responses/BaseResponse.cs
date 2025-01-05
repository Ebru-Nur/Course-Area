using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Shared.Responses
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public BaseResponse(bool success, string message, T? data = default)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static BaseResponse<T> SuccessResponse(T data, string message = "Success") =>
            new(true, message, data);

        public static BaseResponse<T> ErrorResponse(string message) =>
            new(false, message);
    }
}
