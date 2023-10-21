using CretanMusicians.Domain.Entities;
using CretanMusicians.Infrastructure.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CretanMusicians.Infrastructure.DatabaseContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
        => builder.ApplyConfigurationsFromAssembly(typeof(MusicianConfiguration).Assembly);

    public DbSet<Musician> Musicians { get; private set; } = null!;
}