using Data.Sql.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Sql
{
    public class WebContext : DbContext
    {
        public DbSet<UserDbModel> Users { get; set; }

        public DbSet<CartModel> Carts { get; set; }

        public WebContext() { }

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