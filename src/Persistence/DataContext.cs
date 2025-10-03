using Microsoft.EntityFrameworkCore;
using SneakPeek.Models;

namespace Persistence;

public class DataContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public static void Seed(DataContext context)
    {
        // Check if database is empty
        if (context.Movies.Any())
        {
            return; // Database already has data
        }

        // Seed with movie data
        var movies = new List<Movie>
        {
            new Movie
            {
                Title = "Inception",
                Wait = "no wait",
                Description = "A skilled thief, the absolute best in the dangerous art of extraction, steals valuable secrets from deep within the subconscious during the dream state.",
                Release_date = "2010-07-16",
                Genre = "Science Fiction",
                Directors = new List<string> { "Christopher Nolan" },
                Rating = 8.8
            },
            new Movie
            {
                Title = "The Matrix",
                Wait = "no wait",
                Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                Release_date = "1999-03-31",
                Genre = "Action, Science Fiction",
                Directors = new List<string> { "Lana Wachowski", "Lilly Wachowski" },
                Rating = 8.7
            },
            new Movie
            {
                Title = "Parasite",
                Wait = "wait",
                Description = "A poor family schemes to become employed by a wealthy family and infiltrate their household by posing as unrelated, highly qualified individuals.",
                Release_date = "2019-05-30",
                Genre = "Thriller, Drama",
                Directors = new List<string> { "Bong Joon-ho" },
                Rating = 8.6
            },
            new Movie
            {
                Title = "Interstellar",
                Wait = "no wait",
                Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                Release_date = "2014-11-07",
                Genre = "Science Fiction, Adventure",
                Directors = new List<string> { "Christopher Nolan" },
                Rating = 8.6
            },
            new Movie
            {
                Title = "The Godfather",
                Wait = "wait",
                Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                Release_date = "1972-03-24",
                Genre = "Crime, Drama",
                Directors = new List<string> { "Francis Ford Coppola" },
                Rating = 9.2
            }
        };

        context.Movies.AddRange(movies);
        context.SaveChanges();
    }
}
