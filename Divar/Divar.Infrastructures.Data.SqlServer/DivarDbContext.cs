using Divar.Core.Domain.Advertisements.Entities;
using Microsoft.EntityFrameworkCore;

namespace Divar.Infrastructures.Data.SqlServer
{
    public class DivarDbContext : DbContext
    {
        public DivarDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DbSet<Advertisement> Advertisements { get; set; }

    }
}
