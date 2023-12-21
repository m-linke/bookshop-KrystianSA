using System.Collections.Generic;

namespace BookShop.Models.Abstractions
{
    public interface IPagedResult<TResult>
    {
        IEnumerable<TResult> Items { get; }
        int CurrentPage { get; }
        int PageCount { get; }
        int PageSize { get; }
        int TotalRowCount { get; }
    }
}