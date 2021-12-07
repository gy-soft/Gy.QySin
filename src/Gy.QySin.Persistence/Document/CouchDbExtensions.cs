using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gy.QySin.Persistence.Document
{
    public static class CouchDbExtensions
    {
        public static IServiceCollection UseCouchDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICouchClientFactory>(
                (services) => new CouchClientFactory(configuration.GetConnectionString("CouchDBConnectionString"))
            );
            services.AddScoped<VentasRepository>();
            return services;
        }
    }
}