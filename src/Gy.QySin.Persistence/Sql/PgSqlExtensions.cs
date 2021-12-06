using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Gy.QySin.Application.Common.Interfaces;

namespace Gy.QySin.Persistence.Sql
{
    
    public static class PgSqlExtensions
    {
        /// <summary>
        /// Método de conveniencia para agregar el contexto de base de datos al contenedor de servicios.
        /// </summary>
        /// <param name="services">El contenedor de servicios.</param>
        /// <param name="configuration">Objeto con la configuración de la aplicación.</param>
        /// <returns></returns>
        public static IServiceCollection UsePostgres(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, PgSqlDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PostgresConnectionString"))
            );
            services.AddScoped<IApplicationRepositories, ApplicationRepositories>();
            services.AddScoped<IDbConfigurations, DbConfigurations>();
            return services;
        }
    }
}