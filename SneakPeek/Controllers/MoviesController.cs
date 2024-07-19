using Microsoft.AspNetCore.Mvc;
using SneakPeek.Models;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace SneakPeek.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class MoviesController : ControllerBase
    {

        private readonly IWebHostEnvironment _hostingEnvironment;

        public MoviesController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }// to determine the path relative to the project root

        [HttpGet (Name = "movies")]
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
                        WriteIndented = true // Makes this string formatted correctly
                    });
                    return Content(jsonResult, "application/json"); // Return string in json format
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

}


