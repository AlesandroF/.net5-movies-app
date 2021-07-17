using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Services.Mapping;

namespace IoC.Extensions
{
    public static class MapperExtension
    {
        public static IServiceCollection RegisterMapper(this IServiceCollection services)
        {
            MapperConfiguration mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(sp => mapper.CreateMapper());

            return services;
        }
    }
}