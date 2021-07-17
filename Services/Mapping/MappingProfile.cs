using System.Collections.Generic;
using AutoMapper;
using Domain.Entities;
using Services.Dto;
using Services.Dto.Genre;
using Services.Dto.Movie;

namespace Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieExibitionDto>()
                .ForMember(dest => dest.Genero, source => source.MapFrom(x => x.Genre.Nome))
                .ForMember(dest => dest.Disponivel, source => source.MapFrom(x => x.Ativo == 1 ? "SIM" : "NÃO"));
            
            CreateMap<Movie, MovieRegisterDto>()
                .ReverseMap();
            
            CreateMap<Movie, MovieUpdateDto>()
                .ReverseMap();
            
            CreateMap<IEnumerable<int>, MovieYearsExistDto>()
                .ForMember(dest => dest.Years, source => source.MapFrom(x => x));

            CreateMap<Genre, GenreExibitionDto>();
        }
    }
}