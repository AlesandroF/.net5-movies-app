using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Services;

namespace IoC.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IGenreService, GenreService>();

            return services;
        }
    }
}