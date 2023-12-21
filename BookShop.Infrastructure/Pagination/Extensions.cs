using BookShop.Models;
using BookShop.Models.Abstractions;
using BookShop.Models.Queries.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Pagination
{
    public static class Extensions
    {
        public static async Task<IPagedResult<TResult>> ToPagedResult<TEntity, TResult>(this IOrderedQueryable<TEntity> orderedQuery,
        IPagedQuery<TResult> pagedQuery,
        Expression<Func<TEntity, TResult>> selector, int startPaginationFrom = 1)
        {
            IQueryable<TEntity> query = orderedQuery;
            long pages = 0;

            int totalCount = await orderedQuery.CountAsync();

            if (pagedQuery.CurrentPage > 0)
            {
                query = orderedQuery
                    .Skip((pagedQuery.CurrentPage - startPaginationFrom) * pagedQuery.RowCount)
                    .Take(pagedQuery.RowCount);
                pages = (totalCount + (long)pagedQuery.RowCount - 1) / pagedQuery.RowCount;
            }
            var items = await ToListAsync(query.Select(selector));
            var pagedResponse = new PagedResultModel<TResult>
            {
                Items = items,
                PageSize = pagedQuery.RowCount,
                TotalRowCount = totalCount,
                PageCount = pages <= int.MaxValue ? (int)pages : 1,
                CurrentPage = pagedQuery.CurrentPage
            };

            return pagedResponse;
        }

        private async static Task<List<TEntity>> ToListAsync<TEntity>(IQueryable<TEntity> entities)
        {
            return (entities is IAsyncEnumerable<TEntity>)
                ? await entities.ToListAsync()
                : entities.ToList();
        }
    }
}