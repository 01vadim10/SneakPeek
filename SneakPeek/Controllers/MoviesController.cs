using Microsoft.AspNetCore.Mvc;
using SneakPeek.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
namespace SneakPeek.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class MoviesController : ControllerBase
    {

        [HttpGet (Name = "movies")]
        public string Get()
        {
            //string filePath = "C:\\Users\\yanap\\source\\repos\\SneakPeek\\SneakPeek\\Movies.json";
            //string payload;
            /*using (FileStream openStream = System.IO.File.OpenRead(filePath))
            using (StreamReader reader = new StreamReader(openStream))
            {
                payload = reader.ReadToEndAsync();
            }*/

            return "{\r\n  \"movies\": [\r\n    {\r\n      \"title\": \"Inception\",\r\n      \"wait\": \"no wait\",\r\n      \"description\": \"A skilled thief, the absolute best in the dangerous art of extraction, steals valuable secrets from deep within the subconscious during the dream state.\",\r\n      \"release_date\": \"2010-07-16\",\r\n      \"genre\": \"Science Fiction\",\r\n      \"director\": \"Christopher Nolan\",\r\n      \"rating\": 8.8\r\n    },\r\n    {\r\n      \"title\": \"The Matrix\",\r\n      \"wait\": \"no wait\",\r\n      \"description\": \"A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.\",\r\n      \"release_date\": \"1999-03-31\",\r\n      \"genre\": \"Action, Science Fiction\",\r\n      \"directors\": [ \"Lana Wachowski\", \"Lilly Wachowski\" ],\r\n      \"rating\": 8.7\r\n    },\r\n    {\r\n      \"title\": \"Parasite\",\r\n      \"wait\": \"wait\",\r\n      \"description\": \"A poor family schemes to become employed by a wealthy family and infiltrate their household by posing as unrelated, highly qualified individuals.\",\r\n      \"release_date\": \"2019-05-30\",\r\n      \"genre\": \"Thriller, Drama\",\r\n      \"director\": \"Bong Joon-ho\",\r\n      \"rating\": 8.6\r\n    },\r\n    {\r\n      \"title\": \"Interstellar\",\r\n      \"wait\": \"no wait\",\r\n      \"description\": \"A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.\",\r\n      \"release_date\": \"2014-11-07\",\r\n      \"genre\": \"Science Fiction, Adventure\",\r\n      \"director\": \"Christopher Nolan\",\r\n      \"rating\": 8.6\r\n    },\r\n    {\r\n      \"title\": \"The Godfather\",\r\n      \"wait\": \"wait\",\r\n      \"description\": \"The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.\",\r\n      \"release_date\": \"1972-03-24\",\r\n      \"genre\": \"Crime, Drama\",\r\n      \"director\": \"Francis Ford Coppola\",\r\n      \"rating\": 9.2\r\n    }\r\n  ]\r\n}";

        }
    }

}


