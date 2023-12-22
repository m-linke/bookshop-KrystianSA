using BookShop.Models.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models.Commands
{
    public class UpdateAuthorBookCommand : ICommand
    {
        public UpdateAuthorBookCommand(int authorId)
        {
            AuthorId = authorId;
        }
        public readonly int AuthorId;
    }
}
