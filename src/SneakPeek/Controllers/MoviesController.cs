using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;

namespace SneakPeek.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController(IMoviesRepository moviesRepository) : ControllerBase
{
    private readonly IMoviesRepository _moviesRepository = moviesRepository;

    [HttpGet(Name = "movies")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var movies = await _moviesRepository.GetAllMoviesAsync();
            return Ok(movies);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
