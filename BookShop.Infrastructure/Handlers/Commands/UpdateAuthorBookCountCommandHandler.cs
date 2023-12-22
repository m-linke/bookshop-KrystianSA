using BookShop.Domain;
using BookShop.Infrastructure.Context;
using BookShop.Infrastructure.Handlers.Abstractions;
using BookShop.Infrastructure.Repositories;
using BookShop.Models.Commands;
using BookShop.Models.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Handlers.Commands
{
    public class UpdateAuthorBookCountCommandHandler : ICommandHandler<UpdateAuthorBookCommand>
    {
        private readonly AuthorRepository authorRepository;
        private readonly ShopDbContext shopDbContext;

        public UpdateAuthorBookCountCommandHandler(AuthorRepository authorRepository, ShopDbContext shopDbContext)
        {
            this.authorRepository = authorRepository;
            this.shopDbContext = shopDbContext;
        }
        public async Task Handler(UpdateAuthorBookCommand command)
        {
            var entity = shopDbContext.Authors.Find(command.AuthorId);
            entity.BookCount++;
            await authorRepository.Update(entity);
            await authorRepository.Save();
        }
    }
}
