using BookShop.Infrastructure.Handlers.Commands;
using BookShop.Infrastructure.Handlers.Queries;
using BookShop.Models;
using BookShop.Models.Commands;
using BookShop.Models.Queries;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookShop.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly CreateAuthorCommandHandler createAuthorCommandHandler;
        private readonly GetAuthorListQueryHandler getAuthorListQueryHandler;
        private readonly IValidator<AuthorModel> authorValidator;
        private readonly UpdateAuthorBookCountCommandHandler updateAuthorBooksCommandHandler;

        public AuthorsController(CreateAuthorCommandHandler createAuthorCommandHandler,
            GetAuthorListQueryHandler getAuthorListQueryHandler,
            IValidator<AuthorModel> authorValidator,
            UpdateAuthorBookCountCommandHandler updateAuthorBooksCommandHandler)
        {
            this.createAuthorCommandHandler = createAuthorCommandHandler;
            this.getAuthorListQueryHandler = getAuthorListQueryHandler;
            this.authorValidator = authorValidator;
            this.updateAuthorBooksCommandHandler = updateAuthorBooksCommandHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateAuthor()
        {
            return View(new AuthorModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromForm] AuthorModel model)
        {
            ValidationResult result = await authorValidator.ValidateAsync(model);
            if (result.IsValid)
            {
                await createAuthorCommandHandler.Handler(new CreateAuthorCommand(model.Name, model.Surname));
                return RedirectToAction("AuthorList");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AuthorList([FromQuery] PagedQueryModel model)
        {
            return View(await getAuthorListQueryHandler.Handler(new GetAuthorListQuery(model.CurrentPage, model.RowCount)));
        }
    }
}