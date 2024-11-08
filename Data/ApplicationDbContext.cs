using ClientixAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientixAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Founder> Founders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Дополнительные настройки моделей, если нужно
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Founders)
                .WithOne(f => f.Client)
                .HasForeignKey(f => f.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
