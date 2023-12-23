using BookShop.Domain;
using BookShop.Infrastructure.Context;
using BookShop.Infrastructure.Repositories.Abstractions;

namespace BookShop.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<BookEntity>
    {
        public BookRepository(ShopDbContext shopDbContext) : base(shopDbContext) 
        {
        }
    }
}
