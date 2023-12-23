using System;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain
{
    public class BookEntity
    {
        public int Id { get; private set; }
        public string Title { get; private set; } //Max 100 chars
        public string Description { get; private set; }  //Max 500 chars
        public DateTime ReleaseDate { get; private set; }
        public int AuthorId { get; private set; }
        public AuthorEntity Author { get; private set; }
        public static BookEntity AddBook(string title, string description, DateTime releaseDate, int authorId)
        {
            var result = new BookEntity
            {
                Title = title,
                Description = description,
                ReleaseDate = releaseDate,
                AuthorId = authorId
            };
            return result;
        }
    }
}