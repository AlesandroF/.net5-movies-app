using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Infra.Interface;
using Services.Dto.Genre;
using Services.Interfaces;

namespace Services.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreExibitionDto>> GetAllAsync()
            => _mapper.Map<IEnumerable<GenreExibitionDto>>(await _genreRepository.GetAllAsync());
    }
}