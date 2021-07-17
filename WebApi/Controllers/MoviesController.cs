using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Services.Dto.Movie;
using Services.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieExibitionDto>>> GetAllAsync(DateTime? yearCreated, int? genreId)
            => Ok(await _movieService.GetAllAsync(yearCreated, genreId));

        [HttpGet("allYears")]
        public async Task<ActionResult<MovieYearsExistDto>> GetEveryYearOfSavedMoviesAsync()
            => Ok(await _movieService.GetEveryYearOfSavedMoviesAsync());

        [HttpPost]
        public async Task<ActionResult> RegisterAsync([FromBody] MovieRegisterDto movie)
        {
            try
            {
                await _movieService.CreateAsync(movie);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(new {Message = ex.Error});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] MovieUpdateDto movie)
        {
            await _movieService.UpdateAsync(movie);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _movieService.DeleteAsync(id);
            return NoContent();
        }
    }

    public class Error : ModelStateDictionary
    {
        public string Text { get; set; }
    }
}