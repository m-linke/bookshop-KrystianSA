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
    public class CreateBookCommandHandlerTests
    {

        protected readonly IServiceProvider provider;
        public CreateBookCommandHandlerTests()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ShopDbContext>((options) =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.EnableSensitiveDataLogging();
            });
            services.AddTransient<CreateBookCommandHandler>();
            services.AddTransient<BookRepository>();
            provider = services.BuildServiceProvider();
        }

        [Fact]
        public async Task CreateBookCommandHandler_Success()
        {
            var handler = provider.GetService<CreateBookCommandHandler>();
            var command = new CreateBookCommand("Dziady", "Jakiś Wiersz", DateTime.Now, 1);

            await handler.Handler(command);

            var dbContext = provider.GetService<ShopDbContext>();
            var entity = await dbContext.BookEntity.FirstOrDefaultAsync();
            Assert.NotNull(entity);
            Assert.NotEqual(0,entity.Id);
            Assert.Equal(command.Title, entity.Title);
            Assert.Equal(command.Description, entity.Description);
            Assert.Equal(command.ReleaseDate, entity.ReleaseDate);
            Assert.Equal(command.AuthorId, entity.AuthorId);
        }
    }
}
