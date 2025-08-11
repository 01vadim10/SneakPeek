using Microsoft.EntityFrameworkCore;
using SneakPeek.Models;
using Domain.Interfaces;

namespace Persistence.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly DataContext _context;

        public MoviesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie?> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddMovieAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            _context.Movies.Update(movie); 
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movieToDelete = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movieToDelete != null)
            {
                _context.Movies.Remove(movieToDelete);
                await _context.SaveChangesAsync(); 
            }
        }
    }
}
