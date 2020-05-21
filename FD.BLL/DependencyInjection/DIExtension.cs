using FD.BLL.Services.Reference;
using FD.BLL.Services.User;
using FD.DAL.Repository.Reference;
using FD.DAL.Repository.User;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FD.BLL.DependencyInjection
{
    public static class DIExtension
    {
        public static void ConfigureDI(this IServiceCollection services)
        { 
            //for services
            services.AddScoped<IReferenceService, ReferenceService>();
            services.AddScoped<IUserService, UserService>();
            
            //for repositories
            services.AddScoped<ICovidTestRepository, CovidTestRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            

        }
    }
}
