using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SneakPeek.Controllers;

[ApiController]
[Route("[controller]")]

public class MoviesController : ControllerBase
{
    private readonly IMoviesRepository _moviesRepository;

    public MoviesController(IMoviesRepository moviesRepository)
    {
        _moviesRepository = moviesRepository;
    }

    [HttpGet(Name = "movies")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var movies = await _moviesRepository.GetAllMoviesAsync();
            if (movies == null || !movies.Any())
                return NotFound("No movies found.");

            return Ok(movies);
        }
        catch (Exception)
        {
            return StatusCode(500, $"Internal server error");
        }
    }

}
