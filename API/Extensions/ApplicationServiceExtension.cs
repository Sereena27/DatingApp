using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtension
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<Datacontext>(opt =>
         {
            opt.UseSqlite(config.GetConnectionString("Defaultconnection"));
         });
            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();

            return services;

        }
        

    }
}