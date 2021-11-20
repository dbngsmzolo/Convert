using Backend.Data.Ef.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Ef
{
    public class EfDbContext: DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
        }
        public DbSet<ConversionRate> ConversionRates { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConversionRate>().ToTable("ConversionRate");
        }
    }
}
