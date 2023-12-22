using FluentValidation;
using BookShop.Models;

namespace BookShop.Infrastructure.Validations
{
    public class BookValidator : AbstractValidator<BookModel>
    {
        public BookValidator() 
        {
            RuleFor(x=>x.Title).MaximumLength(100).NotNull();
            RuleFor(x => x.Description).MaximumLength(500);
            RuleFor(x => x.ReleaseDate).NotNull();
        }
    }
}
