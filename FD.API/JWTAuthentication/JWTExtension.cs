using FD.BLL.Models.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FD.API.JWTAuthentication
{
    public static  class JWTExtension
    {
        public static void ConfigureJWT(this IServiceCollection services,byte[] secretKey)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                            var responseModel = new Status()
                            {
                                StatusCode = 900,
                                Message = "Token Expired"
                            };
                            var jsonresponse = JsonConvert.SerializeObject(responseModel);
                            context.NoResult();
                            context.Response.StatusCode = 900;
                            context.Response.ContentType = "application/json";
                            context.Response.WriteAsync(jsonresponse).Wait();
                        }
                        return Task.CompletedTask;
                    },
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        if(!context.HttpContext.User.Identity.IsAuthenticated && context.Response.StatusCode == 200)
                        {
                            var responseModel = new Status()
                            {
                                StatusCode = 401,
                                Message = "Unauthorized"
                            };
                            var jsonresponse = JsonConvert.SerializeObject(responseModel);                            
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            context.Response.WriteAsync(jsonresponse).Wait();
                        }
                        return Task.CompletedTask;
                    },
                    //OnTokenValidated = context =>
                    //{
                    //    var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                    //    //var userId = int.Parse(context.Principal.Identity.Name);
                    //    var userName = context.Principal.Identity.Name;
                    //    var user = userService.GetById(userName);
                    //    if (user == null)
                    //    {
                    //        // return unauthorized if user no longer exists
                    //        context.Fail("Unauthorized");
                    //    }
                    //    return Task.CompletedTask;
                    //}
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
