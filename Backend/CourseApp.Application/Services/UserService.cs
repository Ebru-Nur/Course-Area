using CourseApp.Application.DTOs;
using CourseApp.Application.DTOs.Response;
using CourseApp.Application.Interfaces.Repositories;
using CourseApp.Application.Interfaces.Security;
using CourseApp.Application.Interfaces.Services;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Enums;
using CourseApp.Shared.Constants;
using CourseApp.Shared.Responses;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtHelper _jwtHelper;
        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IJwtHelper jwtHelper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtHelper = jwtHelper;
        }

        public async Task<BaseResponse<AuthResponseDto>> RegisterAsync(UserRegisterDto userRegisterDto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(userRegisterDto.Email);
            if (existingUser != null)
            {
                return BaseResponse<AuthResponseDto>.ErrorResponse(Message.User.EMAIL_BULUNMAKTA);
            }

            var user = new User
            {
                FullName = userRegisterDto.FullName,
                Email = userRegisterDto.Email,
                Title = userRegisterDto.Title,
                Role = RoleType.User,
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, userRegisterDto.Password);
            await _userRepository.AddAsync(user);

            var token = _jwtHelper.GenerateToken(user.Id.ToString(), user.Email, user.Role.ToString());
            var userDto = new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Title = user.Title,
                Role = user.Role.ToString()
            };

            var authResponse = new AuthResponseDto
            {
                Token = token,
                User = userDto
            };

            return BaseResponse<AuthResponseDto>.SuccessResponse(authResponse, Message.User.KAYIT_BASARILI);
        }

        public async Task<BaseResponse<AuthResponseDto>> LoginAsync(UserLoginDto userLoginDto)
        {
            var user = await _userRepository.GetByEmailAsync(userLoginDto.Email);
            if (user == null)
            {
                return BaseResponse<AuthResponseDto>.ErrorResponse(Message.User.KULLANICI_BULUNAMADI);
            }

            var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, userLoginDto.Password);
            if (verificationResult == PasswordVerificationResult.Failed)
            {
                return BaseResponse<AuthResponseDto>.ErrorResponse(Message.User.SIFRE_YANLIS);
            }

            var token = _jwtHelper.GenerateToken(user.Id.ToString(), user.Email, user.Role.ToString());
            var userDto = new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,   
                Email = user.Email,
                Title = user.Title,
                Role = user.Role.ToString()
            };

            var authResponse = new AuthResponseDto
            {
                Token = token,
                User = userDto
            };

            return BaseResponse<AuthResponseDto>.SuccessResponse(authResponse, Message.User.GIRIS_BASARILI);
        }

        public async Task<BaseResponse<UserDto>> UpdateAsync(int id, UserUpdateDto userUpdateDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return BaseResponse<UserDto>.ErrorResponse(Message.User.KULLANICI_BULUNAMADI);
            }

            user.FullName = userUpdateDto.FullName;
            user.Title = userUpdateDto.Title;

            await _userRepository.UpdateAsync(user);

            var userDto = new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Title = user.Title,
                Role = user.Role.ToString()
            };

            return BaseResponse<UserDto>.SuccessResponse(userDto, Message.User.GUNCELLENDI);
        }

        public async Task<BaseResponse<bool>> DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return BaseResponse<bool>.ErrorResponse(Message.User.KULLANICI_BULUNAMADI);
            }

            await _userRepository.DeleteAsync(user);
            return BaseResponse<bool>.SuccessResponse(true, Message.User.SILINDI);
        }

        public async Task<BaseResponse<UserDto>> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return BaseResponse<UserDto>.ErrorResponse(Message.User.KULLANICI_BULUNAMADI);
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Title = user.Title,
                Role = user.Role.ToString()
            };

            return BaseResponse<UserDto>.SuccessResponse(userDto, Message.Common.VERI_GETIRILDI);
        }
    }
}
