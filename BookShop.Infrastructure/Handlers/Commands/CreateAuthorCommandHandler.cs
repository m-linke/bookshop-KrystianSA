using BookShop.Domain;
using BookShop.Infrastructure.Handlers.Abstractions;
using BookShop.Infrastructure.Repositories;
using BookShop.Models.Commands;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Handlers.Commands
{
    public class CreateAuthorCommandHandler : ICommandHandler<CreateAuthorCommand>
    {
        private readonly AuthorRepository repository;

        public CreateAuthorCommandHandler(AuthorRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handler(CreateAuthorCommand command)
        {
            var entity = AuthorEntity.Create(command.Name, command.Surname);
            await repository.Add(entity);
            await repository.Save();
        }
    }
}