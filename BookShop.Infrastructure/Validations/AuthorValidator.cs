using BookShop.Models;
using FluentValidation;

namespace BookShop.Infrastructure.Validations
{
    public class AuthorValidator : AbstractValidator<AuthorModel>
    {
        public AuthorValidator() 
        {
            RuleFor(x=>x.Name).NotNull();
            RuleFor(x => x.Surname).NotNull();   
        }
    }
}