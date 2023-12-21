using BookShop.Models.Abstractions;

namespace BookShop.Models.Queries.Abstractions
{
    public interface IPagedQuery<TResult> : IQuery<IPagedResult<TResult>>
    {
        int CurrentPage { get; }
        int RowCount { get; }
    }
}