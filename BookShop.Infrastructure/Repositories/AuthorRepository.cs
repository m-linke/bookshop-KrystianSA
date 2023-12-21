using BookShop.Domain;
using BookShop.Infrastructure.Context;
using BookShop.Infrastructure.Repositories.Abstractions;

namespace BookShop.Infrastructure.Repositories
{
    public class AuthorRepository : GenericRepository<AuthorEntity>
    {
        public AuthorRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
        }
    }
}