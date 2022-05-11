using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class FilmYonetmenContext : DbContext
    {
        public DbSet<Film> Filmler { get; set; }
        public DbSet<Yonetmen> Yonetmenler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // windows authentication
            string connectionString = "server = .\\SQLEXPRESS; database=FilmYonetmenDb;" +
                "trusted_connection=true;multipleactiveresultsets=true";

            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .HasOne(Film => Film.Yonetmen)
                .WithMany(Yonetmen => Yonetmen.Filmler)
                .HasForeignKey(film => film.YonetmenId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
