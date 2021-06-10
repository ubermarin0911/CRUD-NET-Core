using app.api.Data;
using app.api.Interfaces;
using app.api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace app.api.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
          
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
