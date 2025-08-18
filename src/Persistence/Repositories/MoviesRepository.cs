using Microsoft.EntityFrameworkCore;
using SneakPeek.Models;
using Domain.Interfaces;

namespace Persistence.Repositories;

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
        if (id <= 0)
            throw new ArgumentException("Movie ID must be greater than zero", nameof(id));
        return await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddMovieAsync(Movie movie)
    {
        if (movie == null)
            throw new ArgumentNullException(nameof(movie), "Movie cannot be null");
        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMovieAsync(Movie movie)
    {
        var existingMovie = await _context.Movies.FindAsync(movie.Id);
        if (existingMovie == null)
            throw new ArgumentException($"Movie with ID {movie.Id} not found");

        _context.Entry(existingMovie).CurrentValues.SetValues(movie);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMovieAsync(int id)
    {
        var movieToDelete = await _context.Movies.FindAsync(id);
        if (movieToDelete != null)
        {
            _context.Movies.Remove(movieToDelete);
            await _context.SaveChangesAsync(); 
        }
    }
}