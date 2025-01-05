using CourseApp.Application.Configs;
using CourseApp.Application.Interfaces.Security;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Shared.Helper
{
    //public class JwtHelper : IJwtHelper
    //{
    //    private readonly JwtSettings _jwtSettings;

    //    public JwtHelper(JwtSettings jwtSettings)
    //    {
    //        _jwtSettings = jwtSettings;
    //    }

    //    public string GenerateToken(string userId, string email, string role)
    //    {
    //        var claims = new[]
    //        {
    //            new Claim("id", userId),
    //            new Claim("Role", role),
    //            new Claim("Roles", role),


    //            new Claim(ClaimTypes.Email, email),
    //            new Claim(ClaimTypes.Role, role),
    //        };

    //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
    //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //        var token = new JwtSecurityToken(
    //        issuer: _jwtSettings.Issuer,
    //audience: _jwtSettings.Audience,
    //claims: claims,
    //expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
    //signingCredentials: creds);

    //        return new JwtSecurityTokenHandler().WriteToken(token);
    //    }
    //}
    public class JwtHelper : IJwtHelper
    {
        private readonly JwtSettings _jwtSettings;


        public JwtHelper(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public string GenerateToken(string userId, string email, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", userId),
                new Claim("Role", role),
                new Claim("Roles", role),


                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
