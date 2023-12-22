using BookShop.Domain;
using BookShop.Infrastructure.Context;
using BookShop.Infrastructure.Handlers.Abstractions;
using BookShop.Infrastructure.Repositories;
using BookShop.Models.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Handlers.Commands
{
    public class CreateBookCommandHandler : ICommandHandler<CreateBookCommand>
    {
        private readonly BookRepository bookRepository;
        private readonly ShopDbContext shopDbContext;

        public CreateBookCommandHandler(BookRepository bookRepository, ShopDbContext shopDbContext)
        {
            this.bookRepository = bookRepository;
            this.shopDbContext = shopDbContext;
        }
        public async Task Handler(CreateBookCommand command)
        {
            var entity = BookEntity.AddBook(command.Title, command.Description, command.ReleaseDate, command.AuthorId);
            await bookRepository.Add(entity);
            await bookRepository.Save();
        }
    }
}
