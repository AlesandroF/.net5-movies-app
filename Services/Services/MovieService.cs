using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Infra.Interface;
using Services.Dto.Movie;
using Services.Interfaces;

namespace Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        private const int YEAR_DEFAULT = 1900;
        
        public MovieService(IMovieRepository movieRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<MovieExibitionDto>> GetAllAsync(DateTime? yearCreated, int? genreId)
        {
            DateTime date;
            if (yearCreated.HasValue && yearCreated.Value.Date.Year != YEAR_DEFAULT)
                date = yearCreated.Value;
            else
                date = default;
            
            var movies = await _movieRepository.GetAllAsync(date, genreId);
            return _mapper.Map<IEnumerable<MovieExibitionDto>>(movies);
        }

        public async Task CreateAsync(MovieRegisterDto movie)
        {
            if (await MovieExistAsync(movie.Nome))
                throw new DomainException("Filme já cadastrado");
            
            await _movieRepository.CreateAsync(_mapper.Map<Movie>(movie));
            await _unitOfWork.CommitAsync();
        }
        
        public async Task UpdateAsync(MovieUpdateDto movie)
        {
            await _movieRepository.UpdateAsync(_mapper.Map<Movie>(movie), movie.Id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _movieRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<MovieYearsExistDto> GetEveryYearOfSavedMoviesAsync()
            => _mapper.Map<MovieYearsExistDto>(await _movieRepository.GetEveryYearOfSavedMoviesAsync());

        private async Task<bool> MovieExistAsync(string nome)
            => await _movieRepository.ExistsAsync(nome);
    }
}