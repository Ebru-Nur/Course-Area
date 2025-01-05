using CourseApp.Application.DTOs;
using CourseApp.Application.DTOs.Response;
using CourseApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<BaseResponse<AuthResponseDto>> RegisterAsync(UserRegisterDto userRegisterDto);
        Task<BaseResponse<AuthResponseDto>> LoginAsync(UserLoginDto userLoginDto);
        Task<BaseResponse<UserDto?>> UpdateAsync(int id, UserUpdateDto userUpdateDto);
        Task<BaseResponse<bool>> DeleteAsync(int id);
        Task<BaseResponse<UserDto?>> GetByIdAsync(int id);
    }
}
