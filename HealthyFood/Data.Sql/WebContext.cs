using Data.Interface.Models;
<<<<<<< HEAD
using Data.Sql.Models;
=======
>>>>>>> main
using Microsoft.EntityFrameworkCore;

namespace Data.Sql
{
    public class WebContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Cart> Carts { get; set; }

<<<<<<< HEAD
        public DbSet<BlockModelBAA> Blocks { get; set; }

        public WebContext() { }
=======
        public DbSet<GameCategory> GameCategories { get; set; }

        public DbSet<SimilarGame> SimilarGames { get; set; }

		public DbSet<WikiMcImage> WikiMcImages { get; set; }

		public WebContext() { }
>>>>>>> main

        public WebContext(DbContextOptions<WebContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=HealthyFood;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}