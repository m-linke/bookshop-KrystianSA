using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Repositories.Abstractions
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity>
    {
        protected DbContext context;

        public GenericRepository(DbContext shopDbContext)
        {
            context = shopDbContext;
        }

        public async Task Add(TEntity customer)
        {
            await context.AddAsync(customer);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public Task Update(TEntity customer)
        {
            context.Update(customer);
            return Task.CompletedTask;
        }
    }
}