using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infra.Interface
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetAllAsync(DateTime? yearCreated, int? genreId);
        Task<bool> ExistsAsync(string nome);
        Task<IEnumerable<int>> GetEveryYearOfSavedMoviesAsync();
    }
}