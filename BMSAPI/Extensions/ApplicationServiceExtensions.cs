using BMSAPI.Entities.Commands.Handlers;
using BMSAPI.Repository;
using BMSAPI.Repository.Commands.Command;
using BMSAPI.Repository.Commands.Handlers;
using BMSAPI.Repository.interfaces;

namespace BMSAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<CreateBlogCommandHandler>());
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<UpdateBlogCommandHandler>());
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<DeleteBlogCommandHandler>());
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            return services;
        }
    }
}
