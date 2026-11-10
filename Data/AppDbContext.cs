
using CoffeeNoteBe.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeNoteBe.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Cafe> Cafes => Set<Cafe>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<CafeReviewSummary> CafeReviewSummary => Set<CafeReviewSummary>();
}