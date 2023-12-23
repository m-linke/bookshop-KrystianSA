using BookShop.Domain;
using BookShop.Infrastructure.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Context
{
    public class ShopDbContext : DbContext
    {
        public const string Schema = "shop";

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }

        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<BookEntity> BookEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorEntityConfiguration(Schema));
        }
    }
}