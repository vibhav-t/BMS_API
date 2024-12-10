using BMSAPI.Repository;
using BMSAPI.Repository.interfaces;

namespace BMSAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBlogRepository, BlogRepository>();
            return services;
        }
    }
}
