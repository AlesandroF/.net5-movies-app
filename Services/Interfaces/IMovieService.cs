using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Dto.Movie;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieExibitionDto>> GetAllAsync(DateTime? yearCreated, int? genreId);
        Task CreateAsync(MovieRegisterDto movie);
        Task UpdateAsync(MovieUpdateDto movie);
        Task DeleteAsync(int id);
        Task<MovieYearsExistDto> GetEveryYearOfSavedMoviesAsync();
    }
}