using BookShop.Domain;
using BookShop.Infrastructure.Context;
using BookShop.Models;
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
        public async Task<IEnumerable<BookEntity>> Handler(GetBookListQuery query)
        {
            var dbQuery = shopDbContext.BookEntity
                .AsEnumerable().
                Where(authorId=>authorId.AuthorId==query.AuthorId)
                .OrderBy(id=>id.Id);
            return dbQuery;
        }
    }
}
