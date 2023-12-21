using BookShop.Infrastructure.Handlers.Commands;
using BookShop.Infrastructure.Handlers.Queries;
using BookShop.Models;
using BookShop.Models.Commands;
using BookShop.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookShop.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly CreateAuthorCommandHandler createAuthorCommandHandler;
        private readonly GetAuthorListQueryHandler getAuthorListQueryHandler;

        public AuthorsController(CreateAuthorCommandHandler createAuthorCommandHandler,
            GetAuthorListQueryHandler getAuthorListQueryHandler)
        {
            this.createAuthorCommandHandler = createAuthorCommandHandler;
            this.getAuthorListQueryHandler = getAuthorListQueryHandler;
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
            if (ModelState.IsValid)
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