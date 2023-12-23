using BookShop.Domain;
using BookShop.Infrastructure.Context;
using BookShop.Infrastructure.Handlers.Commands;
using BookShop.Infrastructure.Repositories;
using BookShop.Models.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BookShop.UnitTests
{
    public class UpdateAuthorBookCountCommandHandlerTests
    {
        protected readonly IServiceProvider provider;
        public UpdateAuthorBookCountCommandHandlerTests() 
        {
            var services = new ServiceCollection();
            services.AddTransient<UpdateAuthorBookCountCommandHandler>();
            services.AddDbContext<ShopDbContext>((options) =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.EnableSensitiveDataLogging();
            });
            services.AddTransient<AuthorRepository>();
            provider = services.BuildServiceProvider();
        }

        [Fact]
        public async Task UpdateAuthorBookCountCommandHandler()
        {
            var newEntity = AuthorEntity.Create("Johne", "Doe");
            var dbContext = provider.GetService<ShopDbContext>();
            await dbContext.Authors.AddAsync(newEntity);
            await dbContext.SaveChangesAsync();

            var handler = provider.GetService<UpdateAuthorBookCountCommandHandler>();
            var command = new UpdateAuthorBookCommand(1);
            await handler.Handler(command);

            var entity = await dbContext.Authors.FirstOrDefaultAsync();
            Assert.NotNull(entity);
            Assert.NotEqual(0, entity.BookCount);
            Assert.Equal(1, entity.BookCount);
        }
    }
}
