using BookShop.Domain;
using BookShop.Infrastructure.Context;
using BookShop.Infrastructure.Handlers.Queries;
using BookShop.Models.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookShop.UnitTests
{
    public class GetBookListQueryHandlerTests
    {
        protected readonly IServiceProvider provider;
        public GetBookListQueryHandlerTests()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ShopDbContext>((options) =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.EnableSensitiveDataLogging();
            });
            services.AddTransient<GetBookListQueryHandler>();
            provider = services.BuildServiceProvider();
        }

        [Fact]
        public async Task GetBookListQueryHandler_Success()
        {
            var newEntity = BookEntity.AddBook("Adam Mickiewicz", "Dziady cz. 1", DateTime.Now, 1);
            var dbContext = provider.GetService<ShopDbContext>();
            await dbContext.BookEntity.AddAsync(newEntity);
            await dbContext.SaveChangesAsync();

            var handle = provider.GetService<GetBookListQueryHandler>();
            var query = new GetBookListQuery(1, 1, 1);
            var result = await handle.Handler(query);

            Assert.Equal(query.RowCount, result.PageSize);
            Assert.Equal(query.CurrentPage, result.CurrentPage);
            Assert.Equal(1, result.PageCount);
            Assert.Equal(1, result.TotalRowCount);
            Assert.NotEmpty(result.Items);
        }
    }
}
