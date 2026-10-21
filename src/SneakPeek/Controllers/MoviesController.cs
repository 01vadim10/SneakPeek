using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SneakPeek.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController(IMoviesRepository moviesRepository) : ControllerBase
{

    [HttpGet(Name = "movies")]
    public async Task<IActionResult> Get()
    {
        var movies = await moviesRepository.GetAllMoviesAsync();
        if (movies == null || movies.Count == 0)
            return NotFound("No movies found.");

        return Ok(movies);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchMovies([FromQuery] string query) 
    {
        var movies = await moviesRepository.SearchMoviesAsync(query);
        if (movies == null || movies.Count == 0)
            return NotFound("No movies found.");

        return Ok(movies);
    }
}
