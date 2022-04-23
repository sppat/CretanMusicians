using CretanMusicians.API.Data.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CretanMusicians.API.Data
{
    public class CretanMusiciansDbContext : IdentityDbContext<ApiUser>
    {
        public CretanMusiciansDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Origin> Origins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
