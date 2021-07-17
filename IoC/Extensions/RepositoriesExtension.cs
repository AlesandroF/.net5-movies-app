using Infra.Interface;
using Infra.Repositories;
using Infra.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Extensions
{
    public static class RepositoriesExtension
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}