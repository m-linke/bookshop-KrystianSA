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
    public class CreateAuthorCommandHandlerTests
    {
        protected readonly IServiceProvider provider;

        public CreateAuthorCommandHandlerTests()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ShopDbContext>((options) =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.EnableSensitiveDataLogging();
            });
            services.AddTransient<AuthorRepository>();
            services.AddTransient<CreateAuthorCommandHandler>();
            provider = services.BuildServiceProvider();
        }

        [Fact]
        public async Task CreateAuthorCommandHandler_Success()
        {
            var handler = provider.GetService<CreateAuthorCommandHandler>();
            var command = new CreateAuthorCommand("Johne", "Doe");

            await handler.Handler(command);

            var dbContext = provider.GetService<ShopDbContext>();
            var entity = await dbContext.Authors.FirstOrDefaultAsync();
            Assert.NotNull(entity);
            Assert.NotEqual(0, entity.Id);
            Assert.Equal(command.Name, entity.Name);
            Assert.Equal(command.Surname, entity.Surname);
            Assert.Equal(0, entity.BookCount);
        }
    }
}