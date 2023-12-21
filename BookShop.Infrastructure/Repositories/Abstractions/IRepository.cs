using System.Threading.Tasks;

namespace BookShop.Infrastructure.Repositories.Abstractions
{
    public interface IRepository<TEntity>
    {
        Task Add(TEntity customer);

        Task Update(TEntity customer);

        Task Save();
    }
}