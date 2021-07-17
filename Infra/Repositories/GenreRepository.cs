using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Context;
using Infra.Interface;
using Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly MoviesContext _moviesContext;

        public GenreRepository(MoviesContext moviesContext) : base(moviesContext)
        {
            _moviesContext = moviesContext;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await Query().ToListAsync();
        }
    }
}