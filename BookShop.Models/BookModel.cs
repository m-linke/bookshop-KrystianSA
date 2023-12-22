using System.ComponentModel.DataAnnotations;
using System;

namespace BookShop.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; } 
        public DateTime ReleaseDate { get; set; }
    }
}
