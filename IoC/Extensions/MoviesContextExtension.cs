using Domain.Settings;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Extensions
{
    public static class MoviesContextExtension
    {
        public static IServiceCollection RegisterContexts(this IServiceCollection services, MoviesSettings appSettings)
        {
            services.AddDbContext<MoviesContext>(options => options.UseSqlServer(appSettings.ConnectionStrings,
                x => x.MigrationsAssembly("Infra")));

            return services;
        }
    }
}