using Microsoft.EntityFrameworkCore;

namespace EfCoreInMemoryBug
{
    public class TheDbContext : DbContext
    {
        public TheDbContext(DbContextOptions<TheDbContext> options) : base(options) { }

        public DbSet<Thinger> Thingers { get; set; } = null!;

        public DbSet<DoDar> DoDars { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoDar>()
                .HasOne(d => d.Thinger)
                .WithMany(t => t.DoDars)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
