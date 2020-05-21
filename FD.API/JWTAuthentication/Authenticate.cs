using FD.BLL.JsonModels;
using FD.BLL.Models.Response;
using FD.BLL.Models.User;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FD.API.JWTAuthentication
{
    public static class Authenticate
    {
        public static AuthUser AuthenticateUser(UserModel user, AppSettings appSettings)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    //for role authorization
                    //foreach (var item in user.Role)
                    // {
                    //   new Claim(ClaimTypes.Role, item),
                    // }

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                //Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            var response = new AuthUser()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Token = tokenString
            };
            return response;
        }
    }
}
