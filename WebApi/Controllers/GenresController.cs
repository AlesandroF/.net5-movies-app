using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Dto.Genre;
using Services.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreExibitionDto>>> GetAllAsync()
            => Ok(await _genreService.GetAllAsync());
    }
}