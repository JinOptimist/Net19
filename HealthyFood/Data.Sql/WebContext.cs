using Data.Interface.Models;
using Data.Sql.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Sql
{
	public class WebContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public DbSet<Cart> Carts { get; set; }

        public DbSet<PageWikiBlock> PageWikiBlocks { get; set; }

		public DbSet<GameCategory> GameCategories { get; set; }

		public DbSet<SimilarGame> SimilarGames { get; set; }

        public DbSet<WikiMcImage> WikiMcImages { get; set; }

        public DbSet<WikiTags> WikiTags { get; set; }

        public DbSet<Review> Reviews { get; set; }
        
        public DbSet<Game> Games { get; set; }
		public DbSet<Product> Products { get; set; }

        public DbSet<WikiBlockComment> WikiBlockComments { get; set; }

        public DbSet<StoreItem> StoreItems { get; set; }

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

            modelBuilder.Entity<User>()
                .HasMany(x => x.CreatedGames)
                .WithOne(x => x.Creater)
                .IsRequired(false);

            modelBuilder.Entity<User>()
               .HasMany(x => x.Products)
               .WithOne(x => x.Customer)
               .IsRequired(false);

            modelBuilder.Entity<PageWikiBlock>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Blocks);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Reviews)
                .WithOne(x => x.User);

            modelBuilder.Entity<WikiBlockComment>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Comments)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PageWikiBlock>()
                .HasMany(x => x.Comment)
                .WithOne(x => x.Block)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Manufacturer>()
                .HasMany(x => x.StoreItems)
                .WithOne(x => x.Manufacturer);

            modelBuilder.Entity<StoreItem>()
                .HasMany(x => x.Users)
                .WithMany(x => x.StoreItems);

            modelBuilder.Entity<User>()
                .HasMany(x => x.UploadedImages)
                .WithOne(x => x.ImageUploader)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WikiMcImage>()
                .HasMany(x => x.Tags)
                .WithMany(x => x.Images);

            base.OnModelCreating(modelBuilder);
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=HealthyFood;Trusted_Connection=True;";
			optionsBuilder.UseSqlServer(connectionString);
		}
	}
}