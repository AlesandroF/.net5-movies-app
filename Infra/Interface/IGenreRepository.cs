using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infra.Interface
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<IEnumerable<Genre>> GetAllAsync();
    }
}