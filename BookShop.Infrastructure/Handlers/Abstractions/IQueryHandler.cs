using System.Threading.Tasks;

namespace BookShop.Infrastructure.Handlers.Abstractions
{
    public interface IQueryHandler<TQuery, TResult>
    {
        Task<TResult> Handler(TQuery query);
    }
}