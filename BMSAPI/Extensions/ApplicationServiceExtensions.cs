using BMSAPI.Entities.Commands.Handlers;
using BMSAPI.Repository;
using BMSAPI.Repository.Commands.Handlers;
using BMSAPI.Repository.interfaces;

namespace BMSAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<CreateBlogCommandHandler>());
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<UpdateBlogCommandHandler>());
            return services;
        }
    }
}
