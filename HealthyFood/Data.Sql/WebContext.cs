using Data.Interface.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Sql
{
    public class WebContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<GameCategory> GameCategories { get; set; }

        public DbSet<SimilarGame> SimilarGames { get; set; }

		public DbSet<WikiMcImage> WikiMcImages { get; set; }

        public DbSet<Game> Games { get; set; }

		public WebContext() { }

        public WebContext(DbContextOptions<WebContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasMany(x => x.Genres)//Game
                .WithMany(x => x.Games);//GameCategory

            modelBuilder.Entity<Game>()
                .HasMany(x => x.SecondaryGenres)//Game
                .WithMany(x => x.SecondaryGames);//Genre

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=HealthyFood;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}