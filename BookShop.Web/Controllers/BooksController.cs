﻿using BookShop.Infrastructure.Handlers.Commands;
using BookShop.Models;
using BookShop.Models.Commands;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookShop.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IValidator<BookModel> bookValidator;
        private readonly CreateBookCommandHandler createBookCommandHandler;
        private readonly UpdateAuthorBookCountCommandHandler updateAuthorBookCountCommandHandler;

        public BooksController(IValidator<BookModel> bookValidator,
            CreateBookCommandHandler createBookCommandHandler,
            UpdateAuthorBookCountCommandHandler updateAuthorBookCountCommandHandler)
        {
            this.bookValidator = bookValidator;
            this.createBookCommandHandler = createBookCommandHandler;
            this.updateAuthorBookCountCommandHandler = updateAuthorBookCountCommandHandler;
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View(new BookModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromForm] BookModel model, int id)
        {
            ValidationResult result = await bookValidator.ValidateAsync(model);
            if (result.IsValid)
            {
                await createBookCommandHandler.Handler(new CreateBookCommand(model.Title, model.Description, model.ReleaseDate, id));
                await updateAuthorBookCountCommandHandler.Handler(new UpdateAuthorBookCommand(id));
                return RedirectToAction("AuthorList", "Authors");
            }
            return View(model);
        }
    }
}