using Microsoft.AspNetCore.Mvc;
using SneakPeek.Models;
using System.Text.Json;

namespace SneakPeek.Controllers;

[ApiController]
[Route("[controller]")]

public class MoviesController : ControllerBase
{
    private readonly IWebHostEnvironment _hostingEnvironment;

    public MoviesController(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    [HttpGet(Name = "movies")]
    public async Task<IActionResult> Get()
    {
        string filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Movies.json");

        try
        {
            using (FileStream openStream = System.IO.File.OpenRead(filePath))
            {
                List<Movie> movies = await JsonSerializer.DeserializeAsync<List<Movie>>(openStream);
                string jsonResult = JsonSerializer.Serialize(movies, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                return Content(jsonResult, "application/json; charset=utf-8");
            }
        }
        catch (IOException ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
        catch (JsonException ex)
        {
            return BadRequest($"JSON parsing error: {ex.Message}");
        }
    }
}
