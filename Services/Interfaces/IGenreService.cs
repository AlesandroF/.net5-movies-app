using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Dto.Genre;

namespace Services.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreExibitionDto>> GetAllAsync();
    }
}