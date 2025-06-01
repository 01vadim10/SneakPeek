using Microsoft.EntityFrameworkCore;
using SneakPeek.Models;

namespace Persistence;

public class DataContext : DbContext
{
    public DbSet<Movie>? Movies { get; set; }

    public DataContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}
