using BookShop.Models.Abstractions;
using System.Collections.Generic;

namespace BookShop.Models
{
    public class PagedResultModel<TResult> : IPagedResult<TResult>
    {
        public IEnumerable<TResult> Items { get; set; }

        public int CurrentPage { get; set; }

        public int PageCount { get; set; }

        public int PageSize { get; set; }

        public int TotalRowCount { get; set; }
    }
}