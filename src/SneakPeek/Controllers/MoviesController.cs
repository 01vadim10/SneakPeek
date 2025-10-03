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
        try
        {
            var movies = await moviesRepository.GetAllMoviesAsync();
            if (movies == null || movies.Count == 0)
                return NotFound("No movies found.");

            return Ok(movies);
        }
        catch (Exception)
        {
            return StatusCode(500, $"Internal server error");
        }
    }

}
