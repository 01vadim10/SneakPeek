using SneakPeek.Models;

namespace Domain.Interfaces
{
    public interface IMoviesRepository
    {
        Task<List<Movie>> GetAllMoviesAsync();

        Task<Movie?> GetMovieByIdAsync(int id);

        Task AddMovieAsync(Movie movie);

        Task UpdateMovieAsync(Movie movie);

        Task DeleteMovieAsync(int id);
    }
}