using System.Threading.Tasks;

namespace BookShop.Infrastructure.Handlers.Abstractions
{
    public interface ICommandHandler<TCommand>
    {
        Task Handler(TCommand command);
    }
}