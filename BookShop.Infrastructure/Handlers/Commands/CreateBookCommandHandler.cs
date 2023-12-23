using BookShop.Domain;
using BookShop.Infrastructure.Handlers.Abstractions;
using BookShop.Infrastructure.Repositories;
using BookShop.Models.Commands;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Handlers.Commands
{
    public class CreateBookCommandHandler : ICommandHandler<CreateBookCommand>
    {
        private readonly BookRepository bookRepository;

        public CreateBookCommandHandler(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public async Task Handler(CreateBookCommand command)
        {
            var entity = BookEntity.AddBook(command.Title, command.Description, command.ReleaseDate, command.AuthorId);
            await bookRepository.Add(entity);
            await bookRepository.Save();
        }
    }
}
