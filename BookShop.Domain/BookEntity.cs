using System;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain
{
    public class BookEntity
    {
        public int Id { get; private set; }
        [MaxLength(100), Required]
        public string Title { get; private set; } //Max 100 chars
        [MaxLength(500)]
        public string Description { get; private set; }  //Max 500 chars
        [Required]
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