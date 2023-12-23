using BookShop.Domain;
using BookShop.Infrastructure.Context;
using BookShop.Infrastructure.Pagination;
using BookShop.Models;
using BookShop.Models.Abstractions;
using BookShop.Models.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Handlers.Queries
{
    public class GetBookListQueryHandler
    {
        private readonly ShopDbContext shopDbContext;

        public GetBookListQueryHandler(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }
        public async Task<IPagedResult<BookModel>> Handler(GetBookListQuery query)
        {
            var dbQuery = shopDbContext.BookEntity
                .AsQueryable().
                Where(authorId => authorId.AuthorId == query.AuthorId)
                .OrderBy(id => id.Id);
            var pagedResult = await dbQuery.ToPagedResult(query, x => new BookModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ReleaseDate = x.ReleaseDate
            });
            return pagedResult;
        }
    }
}
