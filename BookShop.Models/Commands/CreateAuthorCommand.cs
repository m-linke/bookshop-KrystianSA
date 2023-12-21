using BookShop.Models.Commands.Abstractions;

namespace BookShop.Models.Commands
{
    public class CreateAuthorCommand : ICommand
    {
        public CreateAuthorCommand(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
    }
}