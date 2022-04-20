using Microsoft.EntityFrameworkCore;

namespace CretanMusicians.API.Data
{
    public class CretanMusiciansDbContext : DbContext
    {
        public CretanMusiciansDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Origin> Origins { get; set; }
    }
}
