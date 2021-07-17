using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Context;
using Infra.Interface;
using Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MoviesContext moviesContext) : base(moviesContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetAllAsync(DateTime? yearCreated, int? genreId)
        {
            return await Query()
                .Include(x => x.Genre)
                .Where(x => (genreId == default || x.GenreId == genreId) && (yearCreated == default(DateTime) || x.DataCriacao.Date.Year == yearCreated.Value.Date.Year))
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync(string nome)
            => await Query().AnyAsync(x => x.Nome == nome);

        public async Task<IEnumerable<int>> GetEveryYearOfSavedMoviesAsync()
            => await Query()
                .Select(x => x.DataCriacao.Date.Year)
                .Distinct()
                .OrderByDescending(x => x)
                .ToListAsync();
    }
}