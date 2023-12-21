using BookShop.Domain;
using BookShop.Infrastructure.Context;
using BookShop.Infrastructure.Handlers.Queries;
using BookShop.Models.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BookShop.UnitTests
{
    public class GetAuthorListQueryHandlerTests
    {
        protected readonly IServiceProvider provider;

        public GetAuthorListQueryHandlerTests()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ShopDbContext>((options) =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.EnableSensitiveDataLogging();
            });
            services.AddTransient<GetAuthorListQueryHandler>();
            provider = services.BuildServiceProvider();
            InitTestData();
        }

        [Fact]
        public async Task GetAuthorListQueryHandler_Success()
        {
            var handle = provider.GetService<GetAuthorListQueryHandler>();
            var query = new GetAuthorListQuery(1, 5);

            var result = await handle.Handler(query);

            Assert.Equal(query.RowCount, result.PageSize);
            Assert.Equal(query.CurrentPage, result.CurrentPage);
            Assert.Equal(4, result.PageCount);
            Assert.Equal(20, result.TotalRowCount);
            Assert.NotEmpty(result.Items);
        }

        private void InitTestData()
        {
            var dbContext = provider.GetService<ShopDbContext>();

            for (int i = 0; i < 20; i++)
            {
                dbContext.Add(AuthorEntity.Create($"Name {i}", $"Surame {i}"));
            }
            dbContext.SaveChanges();
        }
    }
}