using BookShop.Models.Commands.Abstractions;
using Microsoft.VisualBasic;
using System;

namespace BookShop.Models.Commands
{
    public class CreateBookCommand : ICommand
    {

        public CreateBookCommand(string title, string description, DateTime releaseDate, int authorId) 
        {
            Title = title;
            Description = description;
            ReleaseDate = releaseDate;
            AuthorId = authorId;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AuthorId { get; set; }
    }
}
