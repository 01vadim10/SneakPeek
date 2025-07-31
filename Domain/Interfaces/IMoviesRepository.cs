using SneakPeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
