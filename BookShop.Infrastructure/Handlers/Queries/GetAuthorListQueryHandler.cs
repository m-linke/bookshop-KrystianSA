using BookShop.Infrastructure.Context;
using BookShop.Infrastructure.Handlers.Abstractions;
using BookShop.Infrastructure.Pagination;
using BookShop.Models;
using BookShop.Models.Abstractions;
using BookShop.Models.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Handlers.Queries
{
    public class GetAuthorListQueryHandler : IQueryHandler<GetAuthorListQuery, IPagedResult<AuthorModel>>
    {
        private readonly ShopDbContext dbContext;

        public GetAuthorListQueryHandler(ShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IPagedResult<AuthorModel>> Handler(GetAuthorListQuery query)
        {
            var dbQuery = dbContext.Authors.AsQueryable().OrderBy(x => x.Id);
            var pagedResult = await dbQuery.ToPagedResult(query, x => new AuthorModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname
            });
            return pagedResult;
        }
    }
}