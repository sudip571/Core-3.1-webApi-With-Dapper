using FD.BLL.JsonModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FD.API.JsonClassConfig
{
    public static class JsonClassExtension
    {
        public static void ConfigureJsonClass(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
        }
    }
}