using SocialIntractionApplication.Repository.Contracts;
using SocialIntractionApplication.Repository.Repositories;
using SocialIntractionApplication.Repository;
using SocialIntractionApplication.Service.Contracts;
using SocialIntractionApplication.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace SocialIntractionApp.Extentions
{
    public static class ApplicationServiceExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Db Context
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //register services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
